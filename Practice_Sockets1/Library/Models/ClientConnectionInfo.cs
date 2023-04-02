using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
	[MessagePackObject]
	public class ClientConnectionInfo
	{
		[Key(0)]
		public string Login { get; set; } = string.Empty;
		[Key(1)]
		public string Password { get; set; } = string.Empty;
	}
}
