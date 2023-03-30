using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
	internal class ClientConnection
	{
		private Socket client;

		public ClientConnection(Socket client)
		{
			this.client = client;
		}

		public Task StartMessagingAsync() => Task.Run(StartMessaging);

		public void StartMessaging()
		{
			string? ip = client.RemoteEndPoint?.ToString();
			if (ip is null) return;

			string answerText = "Hello Client!";
			byte[] answerData = Encoding.UTF8.GetBytes(answerText);

			StringBuilder sb = new();
			int len;

			try
			{
				byte[] data = new byte[100];

				do
				{
					len = client.Receive(data);
					sb.Append(Encoding.UTF8.GetString(data, 0, len));
				} while (client.Available > 0);

				Console.WriteLine($"|{DateTime.Now.ToShortTimeString()}| from {ip} was given message: {sb}");

				client.Send(answerData);
				sb.Clear();

				client.Shutdown(SocketShutdown.Both);
				client.Close();

                Console.WriteLine($"Client with ip {ip} has been disconnected!");
            }
			catch (Exception ex)
			{
                Console.WriteLine("Error was occured: " + ex.Message);
            }
		}
	}
}
