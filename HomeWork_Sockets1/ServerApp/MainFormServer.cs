using Library.Server;
using System.Net;

namespace ServerApp
{
	public partial class MainFormServer : Form
	{
		private Server? _server;

		public MainFormServer()
		{
			InitializeComponent();
			ChangeState(false);
		}


		private void ChangeState(bool connected = true)
		{
			GroupBox_Connection.Enabled = !connected;
			GroupBox_ClientsManaging.Enabled = connected;
			Btn_Start.Enabled = !connected;
			Btn_Stop.Enabled = connected;
		}


		private async void Btn_Start_Click(object sender, EventArgs e)
		{
			if (_server is not null) return;

			if (string.IsNullOrEmpty(TextBox_IpAddres.Text)) return;
			if (!int.TryParse(TextBox_CountOfMaxClients.Text, out int count)) return;

			_server = new(IPAddress.Parse(TextBox_IpAddres.Text), (int)NUD_Port.Value, count);
			_server.ServerMessage += Server_ServerMessage;
			try
			{
				await _server.StartServerAsync();
			}
			finally
			{
				ChangeState();
			}
		}

		private void Server_ServerMessage(string message)
		{
			MessageReceived(message);
		}

		private void Btn_Stop_Click(object sender, EventArgs e)
		{
			if (_server is null) return;

			try
			{
				_server.StopServer();
				_server = null;
			}
			finally
			{
				ChangeState(false);
			}
		}


		private async void Btn_AddClient_Click(object sender, EventArgs e)
		{
			if (_server is null) return;
			if (string.IsNullOrEmpty(TextBox_Login.Text)) return;
			if (string.IsNullOrEmpty(TextBox_Password.Text)) return;
			if (!int.TryParse(TextBox_MaxCountOfQueries.Text, out int count)) return;

			await _server.AddClientToBase(TextBox_Login.Text, TextBox_Password.Text, count);
		}

		private void MessageReceived(string message)
		{
			TextBox_ServerLogs.Invoke(() =>
			{
				var quotes = TextBox_ServerLogs.Lines.ToList();
				quotes.Insert(0, message);
				TextBox_ServerLogs.Lines = quotes.ToArray();
			});
		}
	}
}