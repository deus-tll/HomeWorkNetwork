using LibraryModels;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
	internal class ClientConnection
	{
		private Socket client;
		public ClientConnection(Socket client)
		{
			this.client = client;
		}

		public Task StartOrderingCommandsAsync() => Task.Run(StartOrderingCommands);

		public void StartOrderingCommands()
		{
			string? ip = client.RemoteEndPoint?.ToString();
			if (ip is null) return;

			try
			{
				while (true)
				{
					byte[] bytes = new byte[256];
					MemoryStream ms = new();
					do
					{
						int bytesRead = client.Receive(bytes);
						ms.Write(bytes, 0, bytesRead);
					} while (client.Available > 0);

					ms.Position = 0;
					MyData data = MessagePackSerializer.Deserialize<MyData>(ms);

					if (data.Command == Command.Exit)
					{
						Console.WriteLine($"Client {ip} has been disconnected.");
						break;
					}

					OrderingCommand.ChooseAndSendCommand(client, data);
				}

				client.Shutdown(SocketShutdown.Both);
				client.Close();
			}
			catch (Exception ex)
			{
                Console.WriteLine("Error was occured: " + ex.Message);
            }
		}
	}
}
