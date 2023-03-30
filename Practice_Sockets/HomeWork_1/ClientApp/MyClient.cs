using LibraryModels;
using MessagePack;
using System.Net;
using System.Net.Sockets;

namespace ClientApp
{
	public class MyClient
	{
		private IPAddress ip = IPAddress.Parse("127.0.0.1");
		private int port = 1000;

		private IPEndPoint remoteEndPoint;
		private Socket socket;

		public delegate void ReceivingDataDelegate(MyData data);
		public event ReceivingDataDelegate? ReceivingData;

		public MyClient()
		{
			remoteEndPoint = new(ip, port);
			socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(remoteEndPoint);
		}

		public void OrderCommand(MyData data)
		{
			try
			{
				byte[] bytes = MessagePackSerializer.Serialize(data);
				socket.Send(bytes);

				bytes = new byte[256];
				MemoryStream ms = new();
				do
				{
					int bytesRead = socket.Receive(bytes);
					ms.Write(bytes, 0, bytesRead);
				} while (socket.Available > 0);

				if (data.Command is not Command.Exit)
				{
					ms.Position = 0;
					data = MessagePackSerializer.Deserialize<MyData>(ms);
				}
				else
				{
					socket?.Shutdown(SocketShutdown.Both);
					socket?.Close();
				}

				ReceivingData?.Invoke(data);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
