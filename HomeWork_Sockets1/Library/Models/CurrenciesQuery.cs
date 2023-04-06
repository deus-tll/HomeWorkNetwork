using MessagePack;

namespace Library.Models
{
	[MessagePackObject]
	public class CurrenciesQuery
	{
		[Key(0)]
		public Currency FromCurrency { get; set; }
		[Key(1)]
		public Currency ToCurrency { get; set; }
		[Key(2)]
		public double Exchange { get; set; }
	}
}
