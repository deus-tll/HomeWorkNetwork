namespace LibraryModels
{
	[MessagePackObject]
	public class MyData
	{
		[Key(0)]
		public object? Content { get; set; }
		[Key(1)]
		public Command Command { get; set; }
	}
}
