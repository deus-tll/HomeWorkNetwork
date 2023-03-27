using LibraryModels;
using MessagePack;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Drawing.Imaging;
using System.Linq;

namespace ServerApp
{
	public class MyServer
	{
		private readonly int port;
		private readonly IPAddress ip;

		public MyServer(IPAddress ip, int port)
		{
			this.ip = ip;
			this.port = port;
		}

		public void StartServer()
		{
			Socket server = new (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint endPoint = new(ip, port);

			try
			{
				server.Bind(endPoint);

				server.Listen(10);

				Console.WriteLine("Server started, accept connections...");

				server.BeginAccept(AcceptCallback, server);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error was occured: " + ex.Message);
			}
		}

		public void AcceptCallback(IAsyncResult result)
		{
			Socket? server = result.AsyncState as Socket;
			if (server is null)
			{
                Console.WriteLine("Socket wasn't initialized!");
				Console.ReadKey();
				return;
            }

			Socket client = server.EndAccept(result);
			ClientConnection connection = new(client);
			connection.StartOrderingCommandsAsync();

			server.BeginAccept(AcceptCallback, server);
		}
	}
}
