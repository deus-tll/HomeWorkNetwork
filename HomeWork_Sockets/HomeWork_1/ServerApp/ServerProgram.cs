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

			Console.WriteLine("Press enter key to stop server");
			Console.ReadLine();
		}
	}
}