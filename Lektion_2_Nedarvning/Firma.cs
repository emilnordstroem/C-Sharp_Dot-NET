using System;
using System.Collections.Generic;
using System.Text;

public class Firma : IHarAdresse
{
    public Firma (string navn, Adresse adresse)
    {
        Navn = navn;
        Adresse = adresse;
    }
    public string Navn { get; set; }
    public Adresse Adresse { get; set; }
}
