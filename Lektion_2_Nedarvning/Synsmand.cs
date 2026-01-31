using System;
using System.Collections.Generic;
using System.Text;

public class Synsmand : Mekaniker
{
	public int AntalSynPerUge { get; set; }
	public int Ugeloen
	{
		get { return AntalSynPerUge * 290; }
	}
	public override string ToString()
	{
		return $"{base.ToString()}, Antal syn per uge: {AntalSynPerUge}, Ugeløn {Ugeloen}";
	}
}