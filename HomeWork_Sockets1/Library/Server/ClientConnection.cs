using Library.Models;
using System.Net.Sockets;
using System.Net;

namespace Library.Server
{
	public class ClientConnection
	{
		#region Fields and Ctors
		private readonly TcpClient _client;
		public ClientInfo ClientInfo { get; private set; }
		public IPEndPoint? Address { get; private set; }
		private bool _IsFirstQuery = true;
		private ExchangeRatesModel? _exchangeRates;

		private CancellationTokenSource _cts;

		public ClientConnection(TcpClient client, ClientInfo clientInfo)
		{
			this._client = client;
			this.ClientInfo = clientInfo;
			_cts = new CancellationTokenSource();
			if (client.Client.RemoteEndPoint is IPEndPoint address) Address = address;
		}
		#endregion


		#region Events and Delegates
		public delegate void SentExchangeRatesDelegate(IPEndPoint? address, int clientId, string fromCurrency, string toCurrency, double exchange);
		public event SentExchangeRatesDelegate? SentExchangeRates;

		public delegate void ConnectedStateChangeDelegate(ClientConnection clientConnection, int clientId, bool isConnected);
		public event ConnectedStateChangeDelegate? ConnectedStateChange;

		public delegate void ErrorOccuredDelegate(string error);
		public event ErrorOccuredDelegate? ErrorOccured;
		#endregion


		#region Starting Messaging Methods
		public void StartMessagingAsync() => Task.Run(StartMessaging);


		public void StartMessaging()
		{
			InitializeRates();

			Messaging();

			ConnectedStateChange?.Invoke(this, ClientInfo.ClientId, false);
			_client.Close();
		}

		public void StopMessaging()
		{
			_cts.Cancel();
		}


		private async void Messaging()
		{
			NetworkStream ns = _client.GetStream();

			ConnectedStateChange?.Invoke(this, ClientInfo.ClientId, true);
			int currentCountOfQuotes = 0;
			while (true)
			{
				if (_cts.Token.IsCancellationRequested)
				{
					break;
				}

				if (!await DefineReceiveResponse(currentCountOfQuotes))
					break;

				currentCountOfQuotes++;
			}
		}
		#endregion


		#region Messaging Methods
		private async Task<bool> LimitNotExceeded()
		{
			Data? data = await Data.DeserializeAsyncFromStream(_client);

			if (data is not null)
			{
				if (await SendResponse(data))
					return true;
			}
			return false;
		}

		private async Task LimitExceeded()
		{
			Data? data = await Data.DeserializeAsyncFromStream(_client);
			if (data is not null)
			{
				data.Command = Command.Exit;
				data.Content = "Your quote limit has been reached";

				await Send(data);
			}
		}
		#endregion


		#region Sending Data
		private Task<bool> SendResponse(Data data)
		{
			try
			{
				switch (data.Command)
				{
					case Command.Exchange:
						GetAndSendExchangeRate(data);
						return Task.FromResult(true);
					case Command.Exit:
						break;
				}
			}
			catch (Exception ex)
			{
				ErrorOccured?.Invoke(ex.Message);
			}

			return Task.FromResult(false);
		}


		private async Task Send(Data data)
		{
			try
			{
				NetworkStream ns = _client.GetStream();
				await ns.WriteAsync(data.Serialize());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		private void GetAndSendExchangeRate(Data data)
		{
			try
			{
				Sending(data);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}

		private async void InitializeRates()
		{
			string appId = "bf2e26ed21314fb88f753e6904ddbe3a";
			string apiEndpoint = $"https://openexchangerates.org/api/latest.json?app_id={appId}";
			HttpClient httpClient = new();

			try
			{
				_exchangeRates = await ExchangeRate.GetExchangeRates(httpClient, apiEndpoint);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private async void Sending(Data data)
		{
			if (_exchangeRates is null)
				throw new Exception("Exchange Rates were not initialized");

			object[]? objects = data.Content as object[];
			if (objects is null) return;

			string? fromCurrency = objects[0].ToString();
			string? toCurrency = objects[1].ToString();

			if (fromCurrency is null || toCurrency is null) return;

			CurrenciesQuery query = new()
			{
				FromCurrency = (Currency)Enum.Parse(typeof(Currency), fromCurrency),
				ToCurrency = (Currency)Enum.Parse( typeof(Currency), toCurrency),
			};

			try
			{
				query.Exchange = await ExchangeRate.GetExchangeRate(_exchangeRates, query.FromCurrency.ToString(), query.ToCurrency.ToString());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			data.Content = query;

			try
			{
				await Send(data);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			SentExchangeRates?.Invoke(Address, ClientInfo.ClientId, query.FromCurrency.ToString(), query.ToCurrency.ToString(), query.Exchange);
		}
		#endregion


		#region Additional Methods
		private async Task<bool> DefineReceiveResponse(int count)
		{
			if (count < ClientInfo.LimitQueries)
			{
				if (!await LimitNotExceeded())
					return false;
			}
			else
			{
				await LimitExceeded();
				return false;
			}

			return true;
		}
		#endregion
	}
}
