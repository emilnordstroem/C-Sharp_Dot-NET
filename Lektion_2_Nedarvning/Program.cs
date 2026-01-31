
using System;

public class Program
{
	static void Main ()
    {
        CprNr cpr = new CprNr("012345", "6789");
        Adresse adresse = new Adresse("Programmeringsvej", "110");
        Mekaniker mekaniker = new(
            cpr,
            "Emil",
            adresse,
            2026,
            135
        );
		Console.Out.WriteLine(mekaniker.ToString());
		Console.Out.WriteLine($"Mekaniker er en Medarbejder: {mekaniker is Medarbejder}");

		cpr = new CprNr("123456", "7891");
        adresse = new Adresse("Programmeringsvej", "111");
		Værkfører værkfører = new(
            cpr,
            "Emil",
            adresse,
            2026,
            135,
            2026,
            35
        );
		Console.Out.WriteLine(værkfører.ToString());
		Console.Out.WriteLine($"Værkfører er en Mekaniker: {værkfører is Mekaniker}");

		cpr = new CprNr("234567", "8912");
        adresse = new Adresse("Programmeringsvej", "112");
		Synsmand synsmand = new(
            cpr,
            "Emil",
            adresse,
            2026,
            135,
            60
        );
		Console.Out.WriteLine(synsmand.ToString());
		Console.Out.WriteLine($"Synsmand er en Mekaniker: {synsmand is Mekaniker}");


        var medarbejderCollection = new MedarbejderCollection<Adresse>();
        Console.Out.WriteLine(medarbejderCollection.Size());
		
        medarbejderCollection.AddElement(mekaniker.Adresse, mekaniker);
        Console.Out.WriteLine(medarbejderCollection.Size());
        
        medarbejderCollection.AddElement(værkfører.Adresse, værkfører);
        Console.Out.WriteLine(medarbejderCollection.Size());
		
        medarbejderCollection.AddElement(synsmand.Adresse, synsmand);
        Console.Out.WriteLine(medarbejderCollection.Size());

        adresse = new Adresse("Redmond", "1");
        Firma firma = new Firma("Microsoft", adresse);
        medarbejderCollection.AddElement(firma.Adresse, firma);
		Console.Out.WriteLine(medarbejderCollection.Size());

	}
}