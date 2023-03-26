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
		private Socket? server;

		public MyServer(IPAddress ip, int port)
		{
			this.ip = ip;
			this.port = port;
			server = null;
		}

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

				while (true)
				{
					Socket client = server.Accept();
					if (client is null) return;

					Console.WriteLine("Accept connection: " + client.RemoteEndPoint?.ToString());

					byte[] bytes = new byte[256];
					MemoryStream ms = new();
					do
					{
						int bytesRead = client.Receive(bytes);
						ms.Write(bytes, 0, bytesRead);
					} while (client.Available > 0);

					ms.Position = 0;
					MyData data = MessagePackSerializer.Deserialize<MyData>(ms);
					ChooseCommand(client, data);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Err: " + ex.Message);
			}
		}

		public static void ChooseCommand(Socket client, MyData data)
		{
			switch (data.Command)
			{
				case Command.GetDate: GetDateTime(client, data, DateTime.Now.ToLongDateString()); break;
				case Command.GetTime: GetDateTime(client, data, DateTime.Now.ToLongTimeString()); break;
				case Command.GetRandomArray: GetRandomArray(client, data); break;
				case Command.SortArray: SortArray(client, data); break;
				case Command.GetPictureByName: GetPictureByName(client, data); break;
				case Command.StartProcessByName: StartProcess(client, data); break;
			}
		}

		private static void SendDataAndClose(Socket client, MyData data)
		{
			byte[] bytes = MessagePackSerializer.Serialize(data);
			client.Send(bytes);
			client.Shutdown(SocketShutdown.Both);
			client.Close();
		}

		private static void GetDateTime(Socket client, MyData data, string content)
		{
			data.Content = content;

			SendDataAndClose(client, data);
		}

		private static void GetRandomArray(Socket client, MyData data)
		{
			Random random = new();
			int[] array = new int[15];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next(0, 1000);
			}

			data.Content = array;

			SendDataAndClose(client, data);
		}

		private static void SortArray(Socket client, MyData data)
		{
			object[]? objects = data.Content as object[];
			if (objects is null) return;

			int[] array = new int[objects.Length];

			for (int i = 0; i < objects.Length; i++)
			{
				array[i] = Convert.ToInt32(objects[i]);
			}

			Array.Sort(array);

			data.Content = array;

			SendDataAndClose(client, data);
		}

		private static void GetPictureByName(Socket client, MyData data)
		{
			string? pictureName = data.Content as string;
			if (pictureName is null) return;

			string folderPath = @"Pictures\";
			string fileNameWithoutExtension = pictureName;

			string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
									   .Where(f => Path.GetFileNameWithoutExtension(f) == fileNameWithoutExtension)
									   .ToArray();

			if (files.Length is 0) return;

			Image image = Image.FromFile(files[0]);

			Bitmap bitmap = new(image);

			using (var ms = new MemoryStream())
			{
				bitmap.Save(ms, ImageFormat.Png);

				byte[] bytes = ms.ToArray();

				byte[] messagePackBytes = MessagePackSerializer.Serialize(bytes);

				data.Content = messagePackBytes;

				SendDataAndClose(client, data);
			}

			bitmap.Dispose();
			image.Dispose();
		}

		private static void StartProcess(Socket client, MyData data)
		{
			string? processName = data.Content as string;
			if (processName is null) return;

			Task.Run(() =>
			{
				Process process = new();
				process.StartInfo.FileName = processName;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

				process.Start();

				process.WaitForExit();
				process.Close();
			});

			data.Content = "Application was executed!";

			SendDataAndClose(client, data);
		}
	}
}
