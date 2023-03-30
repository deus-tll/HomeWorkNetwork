using Library;
using System.Net;
using System.Windows.Forms;

namespace ClientApp
{
	public partial class MainFormClient : Form
	{
		private MyClient? client;
		private readonly RadioButton[] radioButtons;
		private string? lastSentMessage;
		private MyData? data;
		public MainFormClient()
		{
			InitializeComponent();
			FormClosing += MainFormClient_FormClosing;
			FillRbTags();

			radioButtons = new RadioButton[]
			{
				RB_ComputerClient_ComputerServer,
				RB_ComputerClient_PersonServer,
				RB_PersonClient_ComputerServer,
				RB_PersonClient_PersonServer
			};
		}

		private void MainFormClient_FormClosing(object? sender, FormClosingEventArgs e)
		{
			Btn_Disconnect_Click(null, null);
		}

		private void FillRbTags()
		{
			RB_ComputerClient_ComputerServer.Tag = Mode.ComputerClient_ComputerServer;
			RB_ComputerClient_PersonServer.Tag = Mode.ComputerClient_PersonServer;
			RB_PersonClient_ComputerServer.Tag = Mode.PersonClient_ComputerServer;
			RB_PersonClient_PersonServer.Tag = Mode.PersonClient_PersonServer;
		}

		private void EnableControls()
		{
			GroupBox_Connection.Enabled = true;
			GroupBox_Mode.Enabled = true;
			Btn_Connect.Enabled = true;
			Btn_Disconnect.Enabled = false;
			Btn_SendMessage.Enabled = false;
			TextBox_Message.Enabled = false;
		}


		private void DisableControls()
		{
			GroupBox_Connection.Enabled = false;
			GroupBox_Mode.Enabled = false;
			Btn_Connect.Enabled = false;
			Btn_Disconnect.Enabled = true;
			Btn_SendMessage.Enabled = true;
			TextBox_Message.Enabled = true;
		}

		private void Btn_SendMessage_Click(object sender, EventArgs e)
		{
			if (client is null || data is null) return;

			lastSentMessage = TextBox_Message.Text;

			Task.Run(() => client.SendMessage(data));
		}

		private void StartMessaging(Mode mode)
		{
			data = new MyData()
			{
				Mode = mode,
				Sender = Sender.Client
			};

			switch (mode)
			{
				case Mode.ComputerClient_PersonServer:
				case Mode.ComputerClient_ComputerServer:
					StartMessagingComputer(data);
					break;
			}
		}

		private void StartMessagingComputer(MyData data)
		{
			TextBox_Message.Enabled = false;
			Btn_SendMessage.Enabled = false;

			Task.Run(() =>
			{
				while (data.Message is not "Bye")
				{
					if (client is null) return;

					client.SendMessage(data);
				}
			});
			
		}

		private Mode? DefiningMode()
		{
			for (int i = 0; i < radioButtons.Length; i++)
			{
				if (radioButtons[i].Checked)
				{
					return (Mode?)radioButtons[i].Tag;
				}
			}

			return null;
		}


		private void Btn_Connect_Click(object sender, EventArgs e)
		{
			if (client is null)
			{
				DisableControls();
				MessageBox.Show("You were connected!");
				client = new(IPAddress.Parse(TextBox_IpAddres.Text), (int)NUD_Port.Value, ReadMessage);
				client.ReceivedMessage += Client_ReceivedMessage;
				client.ErrorOccured += Client_ErrorOccured;
				client.Disconnected += Client_Disconnected;
				client.SentMessage += Client_SentMessage;

				Mode? mode = DefiningMode();
				if (mode is null) return;

				StartMessaging((Mode)mode);
			}
		}

		private void Client_SentMessage(string message)
		{
			Invoke((MethodInvoker)delegate ()
			{
				ListBox_Messages.Items.Insert(0, $"|{DateTime.Now.ToShortTimeString()}|Me: {message}");
			});
		}

		private void Client_Disconnected(string clientIp)
		{
			Btn_Disconnect_Click(null, null);
		}

		private string? ReadMessage()
		{
			if (lastSentMessage is null) return null;

			Invoke((MethodInvoker)delegate ()
			{
				ListBox_Messages.Items.Insert(0, $"|{DateTime.Now.ToShortTimeString()}|Me: {lastSentMessage}");
			});

			return lastSentMessage;
		}

		private void Client_ErrorOccured(string errorMessage)
		{
			Invoke((MethodInvoker)delegate ()
			{
				MessageBox.Show(errorMessage);
			});
		}

		private void Client_ReceivedMessage(string message, string ip)
		{
			Invoke((MethodInvoker)delegate ()
			{
				ListBox_Messages.Items.Insert(0, $"|{DateTime.Now.ToShortTimeString()}|Server {TextBox_IpAddres.Text} sent: {message}");
			});
		}

		private void Btn_Disconnect_Click(object? sender, EventArgs? e)
		{
			if (client is not null)
			{
				Invoke((MethodInvoker)delegate ()
				{
					EnableControls();
				});
				MessageBox.Show("You were disconnected!");
				client = null;
			}
		}


	}
}