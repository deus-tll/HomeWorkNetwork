using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Library.Models;
using Library.DB.Models;
using Library.DB;
using Library.Client;
using MessagePack;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Drawing2D;

namespace Library.Server
{
	public class Server
	{
		private TcpListener? _listener;
		private readonly IPAddress _address;
		private readonly int _port;
		private readonly QuoteGeneratorDB _database;
		public bool IsConnected { get; protected set; } = true;
		public int MaxCountOfClients { get; set; }
		private List<ClientConnection>? _clientConnections;
		private List<Quote>? _quotes;

		public delegate void ServerMessageDelegate(string message);
		public event ServerMessageDelegate? ServerMessage;

		public Server(IPAddress address, int port)
		{
			_address = address;
			_port = port;
			_database = new();
			_database.DatabaseMessage += Database_DatabaseMessage;
		}

		private void Database_DatabaseMessage(string message)
		{
			ServerMessage?.Invoke(message);
		}

		public Task StartServerAsync() => Task.Run(StartServer);

		public async void StartServer()
		{
			if (_listener != null) return;

			_listener = new TcpListener(_address, _port);
			_clientConnections = new List<ClientConnection>();

			_database.ConnectBase();
			await RefreshQuotesList();



			_listener.Start();
			ServerMessage?.Invoke("Server has started! Accept connections...");

			while (true)
			{

				TcpClient client = await _listener.AcceptTcpClientAsync();
				ClientInfo clientInfo = new();

				if (!await TryConnectClient(client, clientInfo)) continue;

				ClientConnection connection = new(client, clientInfo, GetQuotes);
				connection.ConnectedStateChange += Connection_ConnectedStateChange;
				connection.QuoteSent += Connection_QuoteSent;
				connection.ErrorOccured += Connection_ErrorOccured;
				_clientConnections.Add(connection);

				connection.StartMessagingAsync();
			}
		}

		private async Task<bool> TryConnectClient(TcpClient client, ClientInfo clientInfo)
		{
			NetworkStream ns = client.GetStream();
			Data data;
			bool flag;
			if (await ReceiveConnectInfo(client, clientInfo))
			{
				if (_clientConnections?.Count >= MaxCountOfClients)
				{
					flag = false;
					data = DefineResponse(Command.Exit, "The server is under maximum load. Try connecting later.");
				}
				else
				{
					flag = true;
					data = DefineResponse(Command.Message, "You have successfully connected to the server.");
				}
			}
			else
			{
				flag = false;
				data = DefineResponse(Command.Exit, "Invalid login or password.");
			}

			await SendResponse(ns, data);

			return flag;
		}

		private static Data DefineResponse(Command command, string response)
		{
			return new() {Command = command, Response = response };
		}

		private async Task<bool> ReceiveConnectInfo(TcpClient client, ClientInfo clientInfo)
		{
			ClientConnectionInfo connectionInfo;
			NetworkStream ns = client.GetStream();
			byte[] bytes = new byte[256];
			MemoryStream ms = new();
			int bytesRead;
			do
			{
				bytesRead = ns.Read(bytes);
				await ms.WriteAsync(bytes.AsMemory(0, bytesRead));
			} while (client.Available > 0);

			if (bytesRead > 0)
			{
				ms.Position = 0;
				connectionInfo = MessagePackSerializer.Deserialize<ClientConnectionInfo>(ms);

				int? id = await _database.GetClientId(connectionInfo.Login, connectionInfo.Password);
				if (id is null) return false;

				int? limitQuotes = await _database.GetLimitQuotesById(id.Value);

				clientInfo.ClientId = id.Value;
				clientInfo.LimitQuotes = limitQuotes.Value;
				return true;
			}

			return false;
		}

		private async Task SendResponse(NetworkStream ns, Data data)
		{
			try
			{
				byte[] bytes = MessagePackSerializer.Serialize(data);
				await ns.WriteAsync(bytes);
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
				return;
			}
		}

		private async void Connection_QuoteSent(IPEndPoint? address, Quote quote, int clientId)
		{
			await _database.AddLogQuoteClient(clientId, quote.Id);
			ServerMessage?.Invoke($"Quote for {address} >> {quote.Content}");
		}

		public async Task RefreshQuotesList()
		{
			if (_database.IsConnected)
			{
				_quotes?.Clear();
				_quotes = await _database.GetQuotes();
			}
		}

		private List<Quote>? GetQuotes() => _quotes;

		private void Connection_ErrorOccured(string error)
		{
			ServerMessage?.Invoke(error);
		}


		private async void Connection_ConnectedStateChange(ClientConnection clientConnection, int clientId, bool isConnected)
		{
			if (isConnected)
			{
				await _database.AddLogConnectionDisconnection(clientId, "AddLogConnection");
				ServerMessage?.Invoke($"Client {clientConnection.Address} has connected!");
			}
			else
			{
				await _database.AddLogConnectionDisconnection(clientId, "AddLogDisconnection");
				ServerMessage?.Invoke($"Client {clientConnection.Address} has disconnected!");

				if (_clientConnections?.Count > 0)
					_clientConnections.Remove(clientConnection);
			}
		}
	}
}
