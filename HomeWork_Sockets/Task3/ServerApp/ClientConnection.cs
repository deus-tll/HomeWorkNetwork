using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Library;
using MessagePack;

namespace ServerApp
{
	internal class ClientConnection
	{
		private Socket client;

		public delegate void ErrorOccuredDelegate(string errorMessage);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate void ClientDisconnectedDelegate(string clientIp);
		public event ClientDisconnectedDelegate? ClientDisconnected;

		public ClientConnection(Socket client)
		{
			this.client = client;
		}

		public Task StartMessagingAsync() => Task.Run(StartMessaging);

		public void StartMessaging()
		{
			string? ip = client.RemoteEndPoint?.ToString();
			if (ip is null) return;

			try
			{
				while (true)
				{
					byte[] bytes = new byte[256];
					MemoryStream ms = new();
					do
					{
						int bytesRead = client.Receive(bytes);
						ms.Write(bytes, 0, bytesRead);
					} while (client.Available > 0);

					ms.Position = 0;
					MyData data = MessagePackSerializer.Deserialize<MyData>(ms);

					if (data.Message.Equals("Bye"))
					{
						ClientDisconnected?.Invoke(ip);
						break;
					}

					SendingMessage.ChooseModeAndSendMessage(client, data);
				}

				client.Shutdown(SocketShutdown.Both);
				client.Close();
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
			}
		}
	}
}
