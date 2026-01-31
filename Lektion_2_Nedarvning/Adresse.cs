using System;
using System.Collections.Generic;
using System.Text;

public class Adresse
{
	public Adresse (string vejnavn, string nummer)
	{
		Vejnavn = vejnavn;
		Nummer = nummer;
	}
	public string Vejnavn { get; set; }
	public string Nummer { get; set; }
    public override string ToString()
    {
		return $"{Vejnavn} {Nummer}";
    }
}