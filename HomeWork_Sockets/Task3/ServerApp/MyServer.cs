using Library;
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
		public bool IsConnected { get; private set; } 

		#region Delegate/Events
		public delegate void ErrorOccuredDelegate(string errorMessage);
		public event ErrorOccuredDelegate? ErrorOccured;

		public delegate void ClientDisconnectedDelegate(string clientIp);
		public event ClientDisconnectedDelegate? ClientDisconnected;

		public delegate void ClientConnectedDelegate(string clientIp);
		public event ClientDisconnectedDelegate? ClientConnected;

		public delegate void ServerMessageDelegate(string message);
		public event ServerMessageDelegate? ServerMessage;

		public delegate void ServerWasNotInitializedDelegate();
		public event ServerWasNotInitializedDelegate? ServerWasNotInitialized;

		public delegate void ReceivedMessageDelegate(string message, string ip);
		public event ReceivedMessageDelegate? ReceivedMessage;

		public delegate void SentMessageDelegate(string message, string ip);
		public event SentMessageDelegate? SentMessage;


		private readonly ReadMessage.MessageTakenDelegate readMessage;
		#endregion

		public MyServer(IPAddress ip, int port, ReadMessage.MessageTakenDelegate readMessage)
		{
			
			this.ip = ip;
			this.port = port;
			this.readMessage = readMessage;
			
		}

		public void StartServer()
		{
			Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPEndPoint endPoint = new(ip, port);

			try
			{
				server.Bind(endPoint);
				IsConnected = true;

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
			string? s = client.RemoteEndPoint?.ToString();

			if(s is not null)
				ClientConnected?.Invoke(s);

			ClientConnection connection = new(client, readMessage);
			connection.ErrorOccured += Connection_ErrorOccured;
			connection.ClientDisconnected += Connection_ClientDisconnected;
			connection.ReceivedMessage += Connection_ReceivedMessage;
			connection.SentMessage += Connection_SentMessage;

			connection.StartMessagingAsync();

			server.BeginAccept(AcceptCallback, server);
		}

		private void Connection_SentMessage(string message, string ip)
		{
			SentMessage?.Invoke(message, ip);
		}

		private void Connection_ReceivedMessage(string message, string ip)
		{
			ReceivedMessage?.Invoke(message, ip);
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
