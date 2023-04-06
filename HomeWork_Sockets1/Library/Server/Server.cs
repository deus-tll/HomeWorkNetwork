using System.Net.Sockets;
using System.Net;
using Library.DB;
using Library.Models;

namespace Library.Server
{
	public class Server
	{
		#region Fields and Ctors
		private TcpListener? _listener;
		private readonly IPAddress _address;
		private readonly int _port;
		private readonly ExchangeRatesDB _database;
		private List<ClientConnection>? _clientConnections;
		private CancellationTokenSource _cancellationTokenSource;

		public bool IsConnected { get; protected set; }
		private int _maxCountOfClients;

		public Server(IPAddress address, int port, int maxCountOfClients)
		{
			_address = address;
			_port = port;
			_maxCountOfClients = maxCountOfClients;
			_cancellationTokenSource = new();
			_database = new();
			_database.DatabaseMessage += Database_DatabaseMessage; ;
		}
		#endregion


		#region Events and Delegates
		public delegate void ServerMessageDelegate(string message);
		public event ServerMessageDelegate? ServerMessage;

		private void Database_DatabaseMessage(string message)
		{
			ServerMessage?.Invoke(message);
		}


		private void Connection_ErrorOccured(string error)
		{
			ServerMessage?.Invoke(error);
		}


		private async void Connection_SentExchangeRates(IPEndPoint? address, int clientId, string fromCurrency, string toCurrency, double exchange)
		{
			await _database.AddLogClientsQueries(clientId, fromCurrency, toCurrency);
			ServerMessage?.Invoke($"Exchange for {address} >> {fromCurrency} ~ {toCurrency} = {exchange}");
		}


		private void Connection_ConnectedStateChange(ClientConnection clientConnection, int clientId, bool isConnected)
		{
			if (isConnected)
			{
				_database.AddLogConnectionDisconnection(clientId, "AddLogConnection");
				ServerMessage?.Invoke($"Client {clientConnection.Address} has connected!");
			}
			else
			{
				if (_database.IsConnected)
				{
					_database.AddLogConnectionDisconnection(clientId, "AddLogDisconnection");
				}
				ServerMessage?.Invoke($"Client {clientConnection.Address} has disconnected!");

				if (_clientConnections?.Count > 0)
					_clientConnections.Remove(clientConnection);
			}
		}
		#endregion


		#region Starting/stopping Server Methods
		public Task StartServerAsync() => Task.Run(StartServer);

		public async void StartServer()
		{
			if (_listener != null) return;

			_listener = new TcpListener(_address, _port);
			_clientConnections = new List<ClientConnection>();

			_database.ConnectBase();

			_listener.Start();
			IsConnected = true;
			ServerMessage?.Invoke("Server has started! Accept connections...");

			while (true)
			{
				try
				{
					TcpClient client = await _listener.AcceptTcpClientAsync(_cancellationTokenSource.Token);

					ClientInfo clientInfo = new();

					if (!await TryConnectClient(client, clientInfo)) continue;

					ClientConnection connection = new(client, clientInfo);
					connection.ConnectedStateChange += Connection_ConnectedStateChange;
					connection.SentExchangeRates += Connection_SentExchangeRates;
					connection.ErrorOccured += Connection_ErrorOccured;
					_clientConnections.Add(connection);

					connection.StartMessagingAsync();
				}
				catch (Exception)
				{
					break;
				}
			}
		}



		public void StopServer()
		{
			try
			{
				if (_cancellationTokenSource.Token.CanBeCanceled)
					_cancellationTokenSource.Cancel();

				if (_clientConnections is null) return;

				foreach (var connection in _clientConnections)
				{
					connection.StopMessaging();
				}

				_database.DisconnectBase();
				_listener?.Stop();
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
			}
			
		}


		private async Task<bool> TryConnectClient(TcpClient client, ClientInfo clientInfo)
		{
			Data data;
			bool flag;

			if (await ReceiveAuthorizationInfo(client, clientInfo))
			{
				if (_clientConnections?.Count >= _maxCountOfClients)
				{
					flag = false;
					data = DefineResponse(Command.AuthorizationDeclined, "The server is under maximum load. Try connecting later.");
				}
				else
				{
					flag = true;
					data = DefineResponse(Command.AuthorizationConfirmed, "You have successfully connected to the server.");
				}
			}
			else
			{
				flag = false;
				data = DefineResponse(Command.Exit, "Invalid login or password.");
			}

			await SendResponse(client, data);

			return flag;
		}
		#endregion


		#region Receiving Data
		private async Task<bool> ReceiveAuthorizationInfo(TcpClient client, ClientInfo clientInfo)
		{
			NetworkStream ns = client.GetStream();

			Data? data = await Data.DeserializeAsyncFromStream(client);
			if (data is null)
			{
				ServerMessage?.Invoke($"Something went wrong. The data was not deserialized correctly(within server).");
				return false;
			}


			object[]? objects = data.Content as object[];
			if (objects is null)
			{
				ServerMessage?.Invoke($"Something went wrong. The authorization info of client {client.Client.RemoteEndPoint} was missing.");
				return false;
			}


			string? login = objects[0].ToString();
			string? password = objects[1].ToString();


			if (login is null || password is null) return false;

			int? id = await _database.GetClientId(login, password);
			if (id is null) return false;

			int? limitQueries = await _database.GetLimitQueriesById(id.Value);

			clientInfo.ClientId = id.Value;
			clientInfo.LimitQueries = limitQueries.Value;
			return true;
		}
		#endregion


		#region Sending Data
		private async Task SendResponse(TcpClient client,Data data)
		{
			try
			{
				NetworkStream ns = client.GetStream();
				await ns.WriteAsync(data.Serialize());
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
			}
		}
		#endregion


		#region Additional Methods
		private static Data DefineResponse(Command command, string response)
		{
			return new() { Command = command, Content = response };
		}


		public async Task AddClientToBase(string login, string password, int maxCountOfQueries)
		{
			if (_database is null) return;

			await _database.AddClient(login, password, maxCountOfQueries);
		}
		#endregion
	}
}
