using System;
using System.Collections.Generic;
using System.Text;


public class Medarbejder
{
	public string Navn { get; set; }
	public string Adresse { get; set; }

    public override string ToString()
    {
        return $"Navn: {Navn}, Adresse: {Adresse}";
    }
}

