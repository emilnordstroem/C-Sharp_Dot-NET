using System;
using System.Collections.Generic;
using System.Text;

public class Mekaniker : Medarbejder
{
    public Mekaniker (CprNr cpr, string navn, string adresse, int aarForSvendeProeve, double timeloen) : base(cpr, navn, adresse)
    {
        AarForSvendeProeve = aarForSvendeProeve;
        Timeloen = timeloen;
    }

	public int AarForSvendeProeve { get; set; }
	public double Timeloen { get; set; }
    public override double BeregnUgeLoen()
    {
        return TimerPrUge * Timeloen;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, År for Svendeprøve: {AarForSvendeProeve}, Timeløn: {Timeloen}";
    }
}
