using System;
using System.Collections.Generic;
using System.Text;


public abstract class Medarbejder
{

    public Medarbejder(CprNr cpr, string navn, string adresse)
    {
        Navn = navn;
        Adresse = adresse;
        Cpr = cpr;
    }

	public string Navn { get; set; }
	public string Adresse { get; set; }
    public int TimerPrUge 
    {
        get { return 37; }
    }
    public CprNr Cpr { get; set; }

    public abstract double BeregnUgeLoen();

    public override string ToString()
    {
        return $"Cpr: {Cpr}, Navn: {Navn}, Adresse: {Adresse}, Ugeløn: {BeregnUgeLoen()}";
    }
}

