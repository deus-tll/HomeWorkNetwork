namespace ClientApp
{
	public partial class MainFormClient : Form
	{
		private readonly MyClient client = new();
		public MainFormClient()
		{
			InitializeComponent();

			client.MyMessageSent += Client_MyMessageSent;
			client.ServerMessageSent += Client_ServerMessageSent;
		}

		private void Client_ServerMessageSent(string msg)
		{
			AddMessage(msg);
		}

		private void Client_MyMessageSent(string msg)
		{
			AddMessage(msg);
		}

		private void AddMessage(string msg)
		{
			Invoke((MethodInvoker)delegate ()
			{
				TextBox_Messages.AppendText($"{msg}{Environment.NewLine}");
			});
		}

		private async void Btn_Start_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBox_Message.Text)) return;
			await Task.Run(() => client.ConnectSend(TextBox_Message.Text));
		}
	}
}