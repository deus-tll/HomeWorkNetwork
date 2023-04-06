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
			FillComboBoxes();
			FormClosing += MainFormClient_FormClosing;
		}
		#endregion


		#region Additional Methods
		private void ChangeConnectionState(bool connected = true)
		{
			GroupBox_Connection.Enabled = !connected;
			Btn_Connect.Enabled = !connected;
			Btn_GetExchange.Enabled = connected;
			Btn_Disconnect.Enabled = connected;
		}


		private void FillComboBoxes()
		{
			List<Currency> currencies = new();
			foreach (Currency currency in Enum.GetValues(typeof(Currency)))
			{
				currencies.Add(currency);
			}

			ComboBox_FromCurrency.DataSource = currencies;
			ComboBox_ToCurrency.DataSource = new List<Currency>(currencies);
		}


		private void AnswerReceived(string answer)
		{
			TextBox_Exchanges.Invoke(() =>
			{
				var quotes = TextBox_Exchanges.Lines.ToList();
				quotes.Insert(0, answer);
				TextBox_Exchanges.Lines = quotes.ToArray();
			});
		}
		#endregion


		#region Events
		private void MainFormClient_FormClosing(object? sender, FormClosingEventArgs e)
		{
			_client?.Disconnect();
		}


		private void Client_Message(string message)
		{
			MessageBox.Show(message);
		}


		private async void Btn_GetExchange_Click(object sender, EventArgs e)
		{
			if (_client is null) return;

			try
			{
				await SendData();
				await ReceivingData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
				_client.Message += Client_Message;
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


		#region Send Data
		private async Task SendData()
		{
			if (_client is null) return;

			if (ComboBox_FromCurrency.SelectedIndex == -1 ||
				ComboBox_ToCurrency.SelectedIndex == -1)
				throw new Exception("You should choose currencies!");


			Currency fromCurrency = (Currency)ComboBox_FromCurrency.SelectedItem;
			Currency toCurrency = (Currency)ComboBox_ToCurrency.SelectedItem;

			if (fromCurrency == toCurrency)
				throw new Exception("Currencies should be different!");
			

			CurrenciesQuery currenciesQuery = new()
			{
				FromCurrency = fromCurrency,
				ToCurrency = toCurrency
			};

			await _client.Request(new Data()
			{
				Command = Command.Exchange,
				Content = currenciesQuery
			});
		}
		#endregion


		#region Received Data
		private async Task ReceivingData()
		{
			if (_client is null) return;

			Data? data = await _client.ReceiveAnswerAsync() ??
				throw new Exception("Data was not received!");

			ReceivedData(data);
		}


		private void ReceivedData(Data data)
		{
			switch (data.Command)
			{
				case Command.Exchange:
					ExchangeReceived(ref data);
					break;
				case Command.Exit:
					ExitReceived(ref data);
					break;
			}
		}


		private void ExchangeReceived(ref Data data)
		{
			object[]? objects = data.Content as object[];
			if (objects is null) return;

			string? fromCurrency = objects[0].ToString();
			string? toCurrency = objects[1].ToString();

			if (fromCurrency is null || toCurrency is null) return;


			Currency FromCurrency = (Currency)Enum.Parse(typeof(Currency), fromCurrency);
			Currency ToCurrency = (Currency)Enum.Parse(typeof(Currency), toCurrency);

			if (!double.TryParse(objects[2].ToString(), out double exchange)) return;

			string answer = $"Server responded: {FromCurrency} ~ {ToCurrency} = {exchange}";
			AnswerReceived(answer);
		}


		private void ExitReceived(ref Data data)
		{
			if (data.Content is not null)
			{
				AnswerReceived($"Server responded: {data.Content}");
				Btn_Disconnect_Click(null, null);
			}
		}
		#endregion
	}
}