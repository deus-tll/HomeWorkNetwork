using Library.Server;
using System.Net;

namespace ServerApp
{
	internal class ProgramServer
	{
		private static string ip = "127.0.0.1";
		private static int port = 1000;
		static void Main(string[] args)
		{
			Console.Title = "Server| Quote Generator";
			Server server = new(IPAddress.Parse(ip), port);
			server.ServerMessage += Server_ServerMessage;

            Console.WriteLine("Enter max count of clients");
            if (!int.TryParse(Console.ReadLine(), out int n)) return;
			server.MaxCountOfClients = n;

			server.StartServerAsync();

			while (server.IsConnected)
			{
				Thread.Sleep(1000);
			}

			Console.WriteLine("press Enter key...");
			Console.ReadLine();
		}

		private static void Server_ServerMessage(string message)
		{
            Console.WriteLine(message);
        }
	}
}