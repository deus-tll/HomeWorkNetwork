using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Library;
using MessagePack;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
	internal class ClientConnection
	{
		private readonly Socket client;
		private readonly SendingMessage sendingMessage;

		#region Delegate/Events
		public delegate void ErrorOccuredDelegate(string errorMessage);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate void ClientDisconnectedDelegate(string clientIp);
		public event ClientDisconnectedDelegate? ClientDisconnected;

		public delegate void ReceivedMessageDelegate(string message, string ip);
		public event ReceivedMessageDelegate? ReceivedMessage;

		public delegate void SentMessageDelegate(string message, string ip);
		public event SentMessageDelegate? SentMessage;

		private readonly ReadMessage.MessageTakenDelegate readMessage;
		#endregion

		public ClientConnection(Socket client, ReadMessage.MessageTakenDelegate readMessage)
		{
			this.client = client;
			sendingMessage = new SendingMessage();
			sendingMessage.MessageTaken += SendingMessage_MessageTaken;
			this.readMessage = readMessage;
		}

		private string? SendingMessage_MessageTaken()
		{
			return readMessage();
		}

		public Task StartMessagingAsync() => Task.Factory.StartNew(StartMessaging);

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
					int bytesRead;
					MyData data;
					do
					{
						bytesRead = client.Receive(bytes);
						ms.Write(bytes, 0, bytesRead);
					} while (client.Available > 0);

					if (bytesRead > 0)
					{
						ms.Position = 0;
						data = MessagePackSerializer.Deserialize<MyData>(ms);

						ReceivedMessage?.Invoke(data.Message, ip);

						if (data.Message is null || data.Message.Equals("Bye"))
						{
							ClientDisconnected?.Invoke(ip);
							break;
						}

						data.Sender = Sender.Server;
						sendingMessage.MakeAndSendMessage(client, data);

						if (data.Mode == Mode.ComputerClient_ComputerServer ||
							data.Mode == Mode.PersonClient_ComputerServer)
						{
							SentMessage?.Invoke(data.Message, ip);
						}
					}					
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
