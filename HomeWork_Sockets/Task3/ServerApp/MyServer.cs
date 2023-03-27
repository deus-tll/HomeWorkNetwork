using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
	internal class MyServer
	{
		private readonly int port;
		private readonly IPAddress ip;

		public delegate void ErrorOccuredDelegate(string errorMessage);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate void ClientDisconnectedDelegate(string clientIp);
		public event ClientDisconnectedDelegate? ClientDisconnected;

		public delegate void ServerMessageDelegate(string message);
		public event ServerMessageDelegate? ServerMessage;

		public delegate void ServerWasNotInitializedDelegate();
		public event ServerWasNotInitializedDelegate? ServerWasNotInitialized;

		public MyServer(IPAddress ip, int port)
		{
			this.ip = ip;
			this.port = port;
		}

		public void StartServer()
		{
			Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint endPoint = new(ip, port);

			try
			{
				server.Bind(endPoint);

				server.Listen();

				ServerMessage?.Invoke("Server started, accept connections...");

				server.BeginAccept(AcceptCallback, server);
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
			}
		}

		public void AcceptCallback(IAsyncResult result)
		{
			Socket? server = result.AsyncState as Socket;
			if (server is null)
			{
				ServerMessage?.Invoke("Socket wasn't initialized!");
				ServerWasNotInitialized?.Invoke();
				return;
			}

			Socket client = server.EndAccept(result);
			ClientConnection connection = new(client);
			connection.StartMessagingAsync();
			connection.ErrorOccured += Connection_ErrorOccured;
			connection.ClientDisconnected += Connection_ClientDisconnected;

			server.BeginAccept(AcceptCallback, server);
		}

		private void Connection_ClientDisconnected(string clientIp)
		{
			ClientDisconnected?.Invoke(clientIp);
		}

		private void Connection_ErrorOccured(string errorMessage)
		{
			ErrorOccured?.Invoke(errorMessage);
		}
	}
}
