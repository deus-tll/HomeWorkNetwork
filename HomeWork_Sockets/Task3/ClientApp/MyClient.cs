using Library;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientApp
{
	internal class MyClient
	{
		private readonly IPAddress ip;
		private readonly IPEndPoint remoteEndPoint;
		private readonly Socket socket;
		private readonly SendingMessage sendingMessage;

		public delegate void ReceivedMessageDelegate(string message, string ip);
		public event ReceivedMessageDelegate? ReceivedMessage;

		public delegate void ErrorOccuredDelegate(string errorMessage);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate void DisconnectedDelegate(string clientIp);
		public event DisconnectedDelegate? Disconnected;

		public delegate void SentMessageDelegate(string message);
		public event SentMessageDelegate? SentMessage;

		private readonly ReadMessage.MessageTakenDelegate readMessage;

		public MyClient(IPAddress ip, int port, ReadMessage.MessageTakenDelegate readMessage)
		{
			this.ip = ip;
			remoteEndPoint = new(ip, port);
			socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(remoteEndPoint);
			sendingMessage = new SendingMessage();
			sendingMessage.MessageTaken += SendingMessage_MessageTaken;
			sendingMessage.SentMessage += SendingMessage_SentMessage;
			this.readMessage = readMessage;
		}

		private void SendingMessage_SentMessage(string message)
		{
			SentMessage?.Invoke(message);
		}

		private string? SendingMessage_MessageTaken()
		{
			return readMessage();
		}

		public void SendMessage(MyData data)
		{
			try
			{
				sendingMessage.MakeAndSendMessage(socket, data);

				byte[] bytes = new byte[256];
				MemoryStream ms = new();
				do
				{
					int bytesRead = socket.Receive(bytes);
					ms.Write(bytes, 0, bytesRead);
				} while (socket.Available > 0);

				
				if (data.Message is not "Bye")
				{
					ms.Position = 0;
					data = MessagePackSerializer.Deserialize<MyData>(ms);
					if (data.Message is "Bye")
						Bye();
				}
				else
					Bye();
				
				ReceivedMessage?.Invoke(data.Message, ip.ToString());
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
			}
		}

		private void Bye()
		{
			Disconnected?.Invoke(ip.ToString());
			socket?.Shutdown(SocketShutdown.Both);
			socket?.Close();
		}
	}
}
