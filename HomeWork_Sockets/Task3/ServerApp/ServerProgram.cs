using System.Net;

namespace ServerApp
{
	internal class ServerProgram
	{
		static void Main(string[] args)
		{
			Console.Title = "Server";
			MyServer server = new(IPAddress.Parse("127.0.0.1"), 1000);
			server.StartServer();

			server.ErrorOccured += Server_ErrorOccured;
			server.ClientDisconnected += Server_ClientDisconnected;
			server.ServerMessage += Server_ServerMessage;
			server.ServerWasNotInitialized += Server_ServerWasNotInitialized;
			server.MessageTakenFromServer += Server_MessageTakenFromServer; ;

			Console.WriteLine("Press enter key to stop server");
			Console.ReadLine();
		}

		private static string? Server_MessageTakenFromServer()
		{
			return Console.ReadLine();
		}

		private static void Server_ServerWasNotInitialized()
		{
			Console.ReadKey();
		}

		private static void Server_ServerMessage(string message)
		{
            Console.WriteLine(message);
        }

		private static void Server_ClientDisconnected(string clientIp)
		{
            Console.WriteLine($"Client {clientIp} has been disconnected.");
        }

		private static void Server_ErrorOccured(string errorMessage)
		{
            Console.WriteLine($"Error was occured: {errorMessage}");
        }
	}
}