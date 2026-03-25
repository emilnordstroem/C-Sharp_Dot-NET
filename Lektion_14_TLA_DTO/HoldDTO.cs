using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_TLA_DTO
{
	public class HoldDTO
	{
		public string Navn { get; set; }
		public List<string> Studerende { get; set; } = new List<string>();

		public HoldDTO ()
		{

		}

	}
}
