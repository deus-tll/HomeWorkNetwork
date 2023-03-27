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


		public delegate string? MessageTakenDelegate();
		public event MessageTakenDelegate? MessageTaken;

		public SendingMessage()
		{
			preparedPhrases.LoadPhrases();
		}

		public void MakeAndSendMessage(Socket client, MyData data)
		{
			MakeMessage(data);
			SendMessage(client, data);
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
			byte[] bytes = MessagePackSerializer.Serialize(data);
			client.Send(bytes);
		}

		public void EnteredMessage(MyData data)
		{
			string? message = MessageTaken?.Invoke();
			if (string.IsNullOrEmpty(message)) return;

			data.Message = message;
		}

		public void PreparedMessage(MyData data)
		{
			string message = preparedPhrases.Phrases[
				new Random().Next
				(
					preparedPhrases.Phrases.Count + 1
				)];

			data.Message = message;
		}
	}
}
