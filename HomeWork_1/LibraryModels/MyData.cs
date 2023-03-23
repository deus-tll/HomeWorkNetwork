using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
	[MessagePackObject]
	public class MyData
	{
		[Key(0)]
		public object? Content { get; set; }
		[Key(1)]
		public int[]? array { get; set; }
		[Key(2)]
		public Command Command { get; set; }
	}
}
