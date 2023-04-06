using System.Net.Sockets;
using System.Net;
using Library.Models;

namespace Library.Client
{
	public class Client
	{
		#region Fields and Ctors
		private readonly TcpClient _client;
		private IPAddress _address;
		private int _port;

		public bool IsConnected { get; protected set; }

		public Client(IPAddress address, int port)
		{
			_client = new();
			_address = address;
			_port = port;
		}
		#endregion


		#region Events and Delegates
		public delegate void MessageDelegate(string message);
		public event MessageDelegate? Message;
		#endregion


		#region Connect/Disonnect
		public async Task<bool> Connect(string login, string password)
		{
			await _client.ConnectAsync(_address, _port);

			if (_client is null || _client.Client is null)
			{
				Message?.Invoke($"Something went wrong. Client was not initialized.");
				return false;
			}

			AuthorizationInfo info = new() 
			{
				Login = login,
				Password = password 
			};

			await Send(new Data() 
			{
				Command = Command.AuthorizationQuery,
				Content = info
			});

			Data? data = await ReceiveAnswerAsync();
			if (data is null)
			{
				Message?.Invoke($"Something went wrong. The data was not deserialized correctly(within client).");
				return false;
			}

			return Authorization(data);
		}


		public async void Disconnect()
		{
			if (_client is not null && _client.Client is not null)
			{
				await Request(new Data() { Command = Command.Exit });
				Thread.Sleep(700);
				_client.Close();
			}
		}
		#endregion


		#region Receiving Data
		public async Task<Data?> ReceiveAnswerAsync()
		{
			return await Data.DeserializeAsyncFromStream(_client);
		}


		private bool Authorization(Data data)
		{
			string? s = data.Content?.ToString();
			if (s is not null)
				Message?.Invoke(s);

			switch (data.Command)
			{
				case Command.AuthorizationConfirmed:
					return true;
				case Command.AuthorizationDeclined:
					_client.Close();
					break;
			}

			return false;
		}
		#endregion


		#region Sending Data
		public async Task Request(Data data)
		{
			if (_client is not null && _client.Client is not null)
			{
				await Send(data);
			}
		}


		private Task Send(Data data)
		{
			return Task.Run(() =>
			{
				try
				{
					NetworkStream ns = _client.GetStream();
					ns.Write(data.Serialize());
				}
				catch (Exception ex)
				{
					Message?.Invoke(ex.Message);
				}
			});
		}
		#endregion
	}
}
