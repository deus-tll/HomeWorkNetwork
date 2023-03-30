using Library;
using System.Diagnostics;
using System.Net;

namespace ServerApp
{
	internal class ServerProgram
	{
		private static string ip = "127.0.0.1";
		private static int port = 1000;
		static void Main(string[] args)
		{
			Console.Title = "Server";

			MyServer server = CreateServer(IPAddress.Parse(ip), port);
			server.StartServer();

			while (server.IsConnected)
			{
				Thread.Sleep(1000);
			}

			Console.WriteLine("Press enter key to stop server");
			Console.ReadLine();
		}

		private static MyServer CreateServer(IPAddress ip, int port)
		{
			MyServer server = new(ip, port, ReadMessage);
			server.ErrorOccured += Server_ErrorOccured;
			server.ClientDisconnected += Server_ClientDisconnected;
			server.ServerMessage += Server_ServerMessage;
			server.ServerWasNotInitialized += Server_ServerWasNotInitialized;
			server.ClientConnected += Server_ClientConnected;
			server.ReceivedMessage += Server_ReceivedMessage;
			server.SentMessage += Server_SentMessage;

			return server;
		}

		private static void Server_SentMessage(string message, string ip)
		{
			Console.WriteLine($"|{DateTime.Now.ToShortTimeString()}|Server {ip} sent: {message}");
		}

		private static void Server_ClientConnected(string clientIp)
		{
			Console.WriteLine($"Client {clientIp} was connected.");
		}

		private static string? ReadMessage()
		{
			string? message = Console.ReadLine();
			if (message == null) return null;

			return message;
		}

		private static void Server_ReceivedMessage(string message, string ip)
		{
            Console.WriteLine($"|{DateTime.Now.ToShortTimeString()}|Client {ip} sent: {message}");
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