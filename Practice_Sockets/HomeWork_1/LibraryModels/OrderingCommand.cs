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

namespace LibraryModels
{
	public static class OrderingCommand
	{
		public static void ChooseAndSendCommand(Socket client, MyData data)
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

		private static void SendData(Socket client, MyData data)
		{
			byte[] bytes = MessagePackSerializer.Serialize(data);
			client.Send(bytes);
		}

		private static void GetDateTime(Socket client, MyData data, string content)
		{
			data.Content = content;

			SendData(client, data);
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

			SendData(client, data);
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

			SendData(client, data);
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

				SendData(client, data);
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

			SendData(client, data);
		}
	}
}
