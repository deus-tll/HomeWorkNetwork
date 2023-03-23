using System.Net.Sockets;
using System.Net;
using LibraryModels;
using MessagePack;
using System.Drawing;
using System.Diagnostics;

namespace ServerApp
{
	internal class ServerProgram
	{
		static void Main(string[] args)
		{
			Console.Title = "Server";
			MyServer server = new(IPAddress.Parse("127.0.0.1"), 1000);
			Thread thread = new(server.StartServer) 
			{
				IsBackground = true,
			};
			thread.Start();

			Console.WriteLine("Press enter key to stop server");
			Console.ReadLine();
			thread.Abort();
		}
	}
}