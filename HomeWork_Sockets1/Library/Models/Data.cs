using MessagePack;

namespace Library.Models
{
	[MessagePackObject]
	public class Data
	{
		[Key(0)]
		public Command Command { get; set; }
		[Key(1)]
		public object? Content { get; set; }

		//доробити моменти з серіалізацією-десеріалізацією
	}
}