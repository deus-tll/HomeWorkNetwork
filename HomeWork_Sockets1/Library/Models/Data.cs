using MessagePack;
using System.Net.Sockets;

namespace Library.Models
{
	[MessagePackObject]
	public class Data
	{
		[Key(0)]
		public Command Command { get; set; }
		[Key(1)]
		public object? Content { get; set; }

		public static async Task<Data?> DeserializeAsyncFromStream(TcpClient client)
		{
			try
			{
				NetworkStream ns = client.GetStream();
				byte[] bytes = new byte[100];
				int bytesRead;
				using MemoryStream ms = new();
				do
				{
					bytesRead = ns.Read(bytes);
					await ms.WriteAsync(bytes.AsMemory(0, bytesRead));
				} while (client.Available > 0);

				if (bytesRead > 0)
				{
					ms.Position = 0;
					Data data = MessagePackSerializer.Deserialize<Data>(ms);
					return data;
				}
			}
			catch (Exception){}

			return null;
		}

		public byte[] Serialize()
		{
			return MessagePackSerializer.Serialize(this);
		}
	}
}