﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public class MyData
	{
		public Mode Mode {  get; set; }
		public Sender Sender { get; set; }
		public string Message { get; set; } = string.Empty;
	}
}
