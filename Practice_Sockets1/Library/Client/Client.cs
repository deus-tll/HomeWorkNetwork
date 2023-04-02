using System.Net.Sockets;
using System.Net;
using Library.Models;
using MessagePack;

namespace Library.Client
{
	public class Client
	{
		#region Fields and Ctors
		private readonly TcpClient _client;
		private IPAddress _address;
		private int _port;


		public Client(IPAddress address, int port)
		{
			_client = new();
			_address = address;
			_port = port;
		}
		#endregion


		#region Events and Delegates
		public delegate void MessageDelegate(string message);
		public event MessageDelegate? ServerMessage;
		#endregion


		#region Connect/Disonnect
		public async Task<bool> Connect(string login, string password)
		{
			await _client.ConnectAsync(_address, _port);

			if (_client is null || _client.Client is null) return false;

			NetworkStream ns = _client.GetStream();
			ClientConnectionInfo connectionInfo = new() { Login = login, Password = password };
			await Send(ns, connectionInfo);

			Data? data = await ReceiveData();
			if (data is null) return false;

			return IsPermissionReceived(data);
		}


		public async void Disconnect()
		{
			if (_client is not null && _client.Client is not null)
			{
				await Request(Command.Exit);
				Thread.Sleep(700);
				_client.Close();
			}
		}
		#endregion


		#region Receiving
		public async Task<Data?> ReceiveData()
		{
			Data data;
			byte[] bytes = new byte[256];
			MemoryStream ms = new();
			NetworkStream ns = _client.GetStream();
			int bytesRead;
			try
			{
				do
				{
					bytesRead = await ns.ReadAsync(bytes);
					await ms.WriteAsync(bytes.AsMemory(0, bytesRead));
				} while (_client.Available > 0);

				if (bytesRead > 0)
				{
					ms.Position = 0;
					data = MessagePackSerializer.Deserialize<Data>(ms);
					return data;
				}
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
			}

			return null;
		}


		private bool IsPermissionReceived(Data data)
		{
			ServerMessage?.Invoke(data.Response);

			if (data.Command == Command.Message)
				return true;

			return false;
		}
		#endregion


		#region Sending
		public async Task Request(Command command)
		{
			if (_client is not null && _client.Client is not null)
			{
				Data data = new()
				{
					Command = command,
				};
				await Send(_client.GetStream(), data);
			}
		}


		private async Task Send(NetworkStream ns, Data data)
		{
			try
			{
				byte[] bytes = MessagePackSerializer.Serialize(data);
				await ns.WriteAsync(bytes);
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
			}
		}


		private async Task Send(NetworkStream ns, ClientConnectionInfo connectionInfo)
		{
			try
			{
				byte[] bytes = MessagePackSerializer.Serialize(connectionInfo);
				await ns.WriteAsync(bytes);
			}
			catch (Exception ex)
			{
				ServerMessage?.Invoke(ex.Message);
			}
		}
		#endregion
	}
}
