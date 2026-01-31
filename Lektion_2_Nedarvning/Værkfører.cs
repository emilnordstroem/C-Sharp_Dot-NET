using System;
using System.Collections.Generic;
using System.Text;

public class Værkfører : Mekaniker
{
	public int AarForUdnaevelse { get; set; }
	public double UgeTillaeg { get; set; }

	public override string ToString()
	{
		return $"{base.ToString()}, År for Udnævelse: {AarForUdnaevelse}, Uge Tillæg: {UgeTillaeg}";
	}
}
