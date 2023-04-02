using Library.Client;
using Library.Models;
using System.Net;

namespace ClientApp
{
	public partial class MainFormClient : Form
	{
		#region Fields and Ctors
		private Client? _client;
		public MainFormClient()
		{
			InitializeComponent();
			ChangeConnectionState(false);
			FormClosing += MainFormClient_FormClosing;
		}
		#endregion


		#region Additional Methods
		private void ChangeConnectionState(bool connected = true)
		{
			GroupBox_Connection.Enabled = !connected;
			Btn_Connect.Enabled = !connected;
			Btn_GetQuote.Enabled = connected;
			Btn_Disconnect.Enabled = connected;
		}


		private void AnswerReceived(string answer)
		{
			TextBox_Quotes.Invoke(() =>
			{
				var quotes = TextBox_Quotes.Lines.ToList();
				quotes.Insert(0, answer);
				TextBox_Quotes.Lines = quotes.ToArray();
			});
		}
		#endregion


		#region Events
		private void MainFormClient_FormClosing(object? sender, FormClosingEventArgs e)
		{
			_client?.Disconnect();
		}


		private void Client_ServerMessage(string message)
		{
			MessageBox.Show(message);
		}


		private async void Btn_GetQuote_Click(object sender, EventArgs e)
		{
			if (_client is not null)
			{
				await _client.Request(Command.Quote);
				Data? data = await _client.ReceiveData();
				if (data is not null)
				{
					ReceiveData(data);
				}
			}
		}


		private async void Btn_Connect_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBox_IpAddres.Text) ||
				string.IsNullOrEmpty(TextBox_Login.Text) ||
				string.IsNullOrEmpty(TextBox_Password.Text))
				return;

			try
			{
				_client = new(IPAddress.Parse(TextBox_IpAddres.Text), (int)NUD_Port.Value);
				_client.ServerMessage += Client_ServerMessage;
				bool flag = await _client.Connect(TextBox_Login.Text, TextBox_Password.Text);
				ChangeConnectionState(flag);

				if (!flag) _client = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}



		private void Btn_Disconnect_Click(object? sender, EventArgs? e)
		{
			try
			{
				Task.Run(() =>
				{
					_client?.Disconnect();
				});
			}
			finally
			{
				ChangeConnectionState(false);
			}
		}
		#endregion


		#region Receiving Data
		private void ReceiveData(Data data)
		{
			switch (data.Command)
			{
				case Command.Quote:
					QuoteReceived(ref data);
					break;
				case Command.Message:
					MessageReceived(ref data);
					break;
				case Command.Exit:
					ExitReceived(ref data);
					break;
			}
		}


		private void MessageReceived(ref Data data)
		{
			AnswerReceived($"Server responded: {data.Response}");
		}


		private void QuoteReceived(ref Data data)
		{
			AnswerReceived($"Server sent quote: {data.Response}");
		}


		private void ExitReceived(ref Data data)
		{
			AnswerReceived($"Server responded: {data.Response}");
			Btn_Disconnect_Click(null, null);
		}
		#endregion
	}
}