using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public class PreparedPhrases
	{
		public List<string> Phrases = new();

		public void LoadPhrases(string path = "PreparedPhrases.txt")
		{
			Phrases.Clear();
			using StreamReader reader = new(path);
			string? s;
			do
			{
				s = reader.ReadLine();
				if (s is null) break;
				Phrases.Add(s);
			} while (true);
		}
	}
}
