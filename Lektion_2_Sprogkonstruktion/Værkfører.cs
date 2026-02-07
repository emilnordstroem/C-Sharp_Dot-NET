using System;
using System.Collections.Generic;
using System.Text;

public class Værkfører : Mekaniker
{
	public Værkfører(
		CprNr cpr,
		string navn,
		Adresse adresse,
		int aarForSvendeProeve,
		double timeloen,
		int aarForUdnaevelse,
		double ugeTillaeg
		) : base(cpr, navn, adresse, aarForSvendeProeve, timeloen)
	{
		AarForUdnaevelse = aarForUdnaevelse;
		UgeTillaeg = ugeTillaeg;
	}
	public int AarForUdnaevelse { get; set; }
	public double UgeTillaeg { get; set; }

    public override double BeregnUgeLoen()
    {
		return (TimerPrUge * Timeloen) + UgeTillaeg;
    }

	public override string ToString()
	{
		return $"{base.ToString()}, År for Udnævelse: {AarForUdnaevelse}, Uge Tillæg: {UgeTillaeg}";
	}
}
