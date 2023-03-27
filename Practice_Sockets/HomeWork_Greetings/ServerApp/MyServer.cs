using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
	internal class MyServer
	{
		private readonly IPAddress ip;
		private readonly int port;
		public MyServer(IPAddress ip, int port)
		{
			this.ip = ip;
			this.port = port;
		}

		public void StartServer()
		{
			Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint localEndPoint = new(ip, port);

			try
			{
				server.Bind(localEndPoint);

				server.Listen();

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
			connection.StartMessagingAsync();
		}
	}
}
