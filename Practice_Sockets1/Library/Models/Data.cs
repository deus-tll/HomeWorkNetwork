using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
	[MessagePackObject]
	public class Data
	{
		[Key(0)]
		public Command Command { get; set; }
		[Key(1)]
		public string Response { get; set; } = string.Empty;
	}
}
