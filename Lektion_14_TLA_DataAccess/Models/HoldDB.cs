using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_TLA_DataAccess;

internal class HoldDB
{
	public Guid? Id { get; set; }
	public string Navn { get; set; }
	public List<StuderendeDB> Studerende { get; set; } = new List<StuderendeDB>();

	public HoldDB ()
	{

	}

}
