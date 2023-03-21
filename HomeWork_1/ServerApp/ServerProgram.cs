using System.Net.Sockets;
using System.Net;

namespace ServerApp
{
	internal class ServerProgram
	{
		static void Main(string[] args)
		{
			Console.Title = "Server";

		}
	}

	internal class MyServer
	{
		private int port;
		private IPAddress ip;
		private Socket server;

		public Task StartServerAsync() => Task.Run(StartServer);

		public void StartServer()
		{
			if (server is not null)
			{
				return;
			}

			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint endPoint = new(ip, port);

			try
			{
				server.Bind(endPoint);

				server.Listen();
				Console.WriteLine("Server started, accept connection...");


			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}