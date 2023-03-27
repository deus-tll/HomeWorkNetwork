using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
	internal class MyClient
	{
		private IPAddress ip = IPAddress.Loopback;
		private int port = 1000;
		string clientIpAddress;

		public delegate void MyMessageSentDelegate(string msg);
		public event MyMessageSentDelegate? MyMessageSent;

		public delegate void ServerMessageSentDelegate(string msg);
		public event ServerMessageSentDelegate? ServerMessageSent;

		public MyClient()
		{
			string hostName = Dns.GetHostName();
			IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
			IPAddress[] ipAddress = ipEntry.AddressList;
			clientIpAddress = ipAddress[1].ToString();
		}

		public void ConnectSend(string message)
		{
			IPEndPoint remoteEndPoint = new(ip, port);
			Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				socket.Connect(remoteEndPoint);

				byte[] data = Encoding.UTF8.GetBytes(message);

				socket.Send(data);

				MyMessageSent?.Invoke($"|{DateTime.Now.ToShortTimeString()}| from {clientIpAddress} was sent message: {message}");

				StringBuilder sb = new();

				int len;

				data = new byte[100];

				do
				{
					len = socket.Receive(data);
					sb.Append(Encoding.UTF8.GetString(data, 0, len));
				} while (socket.Available > 0);

				ServerMessageSent?.Invoke($"|{DateTime.Now.ToShortTimeString()}| from {ip} was given message: {sb}");

				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
