using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	[MessagePackObject]
	public class MyData
	{
		[Key(0)]
		public Mode Mode {  get; set; }

		[Key(1)]
		public Sender Sender { get; set; }

		[Key(2)]
		public string? Message { get; set; }
	}
}
