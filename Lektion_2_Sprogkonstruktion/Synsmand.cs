using System;
using System.Collections.Generic;
using System.Text;

public class Synsmand : Mekaniker
{
	public Synsmand(
		CprNr cpr, 
		string navn, 
		Adresse adresse, 
		int aarForSvendeProeve, 
		double timeloen,
		int antalSynPrUge
		) : base(cpr, navn, adresse, aarForSvendeProeve, timeloen)
	{
		AntalSynPrUge = antalSynPrUge;
	}
	public int AntalSynPrUge { get; set; }

    public override double BeregnUgeLoen()
    {
		return AntalSynPrUge * 290;
	}
	public override string ToString()
	{
		return $"{base.ToString()}, Antal syn per uge: {AntalSynPrUge}";
	}
}