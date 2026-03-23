using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_TLA_DataAccess;

internal class Hold
{
	public Guid? Id { get; set; }
	public string Navn { get; set; }
	public List<Studerende> Studerende { get; set; } = new List<Studerende>();

	public Hold ()
	{

	}

}
