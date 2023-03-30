using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public class SendingMessage
	{
		private readonly PreparedPhrases preparedPhrases = new();

		public event ReadMessage.MessageTakenDelegate? MessageTaken;

		public delegate void SentMessageDelegate(string message);
		public event SentMessageDelegate? SentMessage;

		public SendingMessage()
		{
			preparedPhrases.LoadPhrases();
		}

		public void MakeAndSendMessage(Socket socket, MyData data)
		{
			MakeMessage(data);
			SendMessage(socket, data);
		}

		private void MakeMessage(MyData data)
		{
			switch (data.Sender)
			{
				case Sender.Server:
					MakeMessageServer(data);
					break;
				case Sender.Client:
					MakeMessageClient(data);
					break;
			}
		}

		private void MakeMessageServer(MyData data)
		{
			switch (data.Mode)
			{
				case Mode.PersonClient_PersonServer:
				case Mode.ComputerClient_PersonServer:
					EnteredMessage(data);
					break;
				case Mode.PersonClient_ComputerServer:
				case Mode.ComputerClient_ComputerServer:
					PreparedMessage(data);
					break;
			}
		}

		private void MakeMessageClient(MyData data)
		{
			switch (data.Mode)
			{
				case Mode.PersonClient_PersonServer:
				case Mode.PersonClient_ComputerServer:
					EnteredMessage(data);
					break;
				case Mode.ComputerClient_PersonServer:
				case Mode.ComputerClient_ComputerServer:
					PreparedMessage(data);
					break;
			}
		}

		private void SendMessage(Socket client, MyData data)
		{
			if (string.IsNullOrEmpty(data.Message)) return;

			byte[] bytes = MessagePackSerializer.Serialize(data);
			client.Send(bytes);
		}

		private void EnteredMessage(MyData data)
		{
			string? message = MessageTaken?.Invoke();

			data.Message = message;
		}

		private void PreparedMessage(MyData data)
		{
			Random random = new();
			string message = preparedPhrases.Phrases[
				random.Next
				(
					preparedPhrases.Phrases.Count
				)];

			data.Message = message;

			SentMessage?.Invoke(message);

			Thread.Sleep(random.Next(100, 300));
		}
	}
}
