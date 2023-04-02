using Library.DB.Models;
using Library.Models;
using MessagePack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Server
{
	internal class ClientConnection
	{
		private readonly TcpClient _client;
		private readonly ClientInfo _clientInfo;
		public IPEndPoint? Address { get; private set; }


		public delegate void QuoteSentDelegate(IPEndPoint? address, Quote quote, int clientId);
		public event QuoteSentDelegate? QuoteSent;

		public delegate void ConnectedDelegate(ClientConnection clientConnection, int clientId, bool isConnected);
		public event ConnectedDelegate? ConnectedStateChange;

		public delegate void ErrorOccuredDelegate(string error);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate List<Quote>? GetQuoteListDelegate();
		private readonly GetQuoteListDelegate GetQuoteList;


		public ClientConnection(TcpClient client, ClientInfo clientInfo, GetQuoteListDelegate getQuoteList)
		{
			this._client = client;
			this._clientInfo = clientInfo;
			GetQuoteList = getQuoteList;
			if (client.Client.RemoteEndPoint is IPEndPoint address) Address = address;
		}

		public void StartMessagingAsync() => Task.Run(StartMessaging);

		public void StartMessaging()
		{
			NetworkStream ns = _client.GetStream();

			Messaging(ns);

			_client.Close();
			ConnectedStateChange?.Invoke(this, _clientInfo.ClientId, false);
		}

		private async void Messaging(NetworkStream ns)
		{
			ConnectedStateChange?.Invoke(this, _clientInfo.ClientId, true);
			int currentCountOfQuotes = 0;
			while (true)
			{
				if (currentCountOfQuotes < _clientInfo.LimitQuotes)
				{
					if (!await LimitNotExceeded(ns))
						break;
				}
				else
				{
					await LimitExceeded(ns);
					break;
				}

				currentCountOfQuotes++;
			}
		}

		private async Task<bool> LimitNotExceeded(NetworkStream ns)
		{
			Data? data = await ReceiveData(ns);
			if (data is not null)
			{
				if (await SendResponse(ns, data))
					return true;
			}
			return false;
		}

		private async Task LimitExceeded(NetworkStream ns)
		{
			Data? data = await ReceiveData(ns);
			if (data is not null)
			{
				await SendResponseLimitExceeded(ns, data);
			}
		}

		private async Task<Data?> ReceiveData(NetworkStream ns)
		{
			Data data;
			byte[] bytes = new byte[256];
			MemoryStream ms = new();
			int bytesRead;
			do
			{
				bytesRead = ns.Read(bytes);
				await ms.WriteAsync(bytes.AsMemory(0, bytesRead));
			} while (_client.Available > 0);

			if (bytesRead > 0)
			{
				ms.Position = 0;
				data = MessagePackSerializer.Deserialize<Data>(ms);
				return data;
			}

			return null;
		}

		private Task<bool> SendResponse(NetworkStream ns, Data data)
		{
			switch (data.Command)
			{
				case Command.Quote:
					GetAndSendQuote(ns, data);
					return Task.FromResult(true);
				case Command.Exit:
					break;
			}
			return Task.FromResult(false);
		}

		private async Task SendResponseLimitExceeded(NetworkStream ns, Data data)
		{
			try
			{
				data.Command = Command.Exit;
				data.Response = "Your quote limit has been reached";
				byte[] bytes = MessagePackSerializer.Serialize(data);
				await ns.WriteAsync(bytes);
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
				return;
			}
		}

		private void GetAndSendQuote(NetworkStream ns, Data data)
		{
			Quote? quote = GetQuote();
			if (quote is null) return;
			data.Response = quote.Content;
			Send(ns, data, quote);
		}


		private Quote? GetQuote()
		{
			Quote? quote = null;
			try
			{
				Random random = new();
				var quotes = GetQuoteList();
				quote = quotes?[random.Next(quotes.Count)];
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
			}

			return quote;
		}

		private async void Send(NetworkStream ns, Data data, Quote quote)
		{
			try
			{
				data.Response = quote.Content;
				byte[] bytes = MessagePackSerializer.Serialize(data);
				await ns.WriteAsync(bytes);
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
				return;
			}
			

			QuoteSent?.Invoke(Address, quote, _clientInfo.ClientId);
		}
	}
}
