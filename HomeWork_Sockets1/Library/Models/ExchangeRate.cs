using Newtonsoft.Json;

namespace Library.Models
{
	public static class ExchangeRate
	{
		public static async Task<ExchangeRatesModel> GetExchangeRates(HttpClient httpClient, string apiEndPoint)
		{
			HttpResponseMessage response = await httpClient.GetAsync(apiEndPoint);

			if (!response.IsSuccessStatusCode)
				throw new Exception($"Failed to fetch exchange rates. Status code: {response.StatusCode}");

			string json = await response.Content.ReadAsStringAsync();

			var exchangeRates = JsonConvert.DeserializeObject<ExchangeRatesModel>(json) ??
				throw new Exception($"Something went wrong. Could not get exchange rates");

			return exchangeRates;
		}

		public static Task<double> GetExchangeRate(ExchangeRatesModel exchangeRates, string fromCurrency, string toCurrency)
		{
			if (exchangeRates.Rates.TryGetValue(toCurrency, out double toRate) &&
				exchangeRates.Rates.TryGetValue(fromCurrency, out double fromRate))
				return Task.FromResult(toRate / fromRate);
			else
				throw new Exception($"Invalid currency pair: {fromCurrency}/{toCurrency}");
		}
	}
	public class ExchangeRatesModel
	{
		public string Base { get; set; }
		public Dictionary<string, double> Rates { get; set; }
	}
}
