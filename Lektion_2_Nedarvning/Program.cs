
using System;

public class Program
{
	static void Main ()
    {
        CprNr cpr = new CprNr("012345", "6789");
        Mekaniker mekaniker = new(
            cpr,
            "Emil",
            "Programmeringsvej 110",
            2026,
            135
        );
		Console.Out.WriteLine(mekaniker.ToString());
		Console.Out.WriteLine($"Mekaniker er en Medarbejder: {mekaniker is Medarbejder}");

		cpr = new CprNr("123456", "7891");
		Værkfører værkfører = new(
            cpr,
            "Emil",
            "Programmeringsvej 110",
            2026,
            135,
            2026,
            35
        );
		Console.Out.WriteLine(værkfører.ToString());
		Console.Out.WriteLine($"Værkfører er en Mekaniker: {værkfører is Mekaniker}");

		cpr = new CprNr("234567", "8912");
		Synsmand synsmand = new(
            cpr,
            "Emil",
            "Programmeringsvej 110",
            2026,
            135,
            60
        );
		Console.Out.WriteLine(synsmand.ToString());
		Console.Out.WriteLine($"Synsmand er en Mekaniker: {synsmand is Mekaniker}");

        var medarbejderCollection = new MedarbejderCollection<CprNr>();
        Console.Out.WriteLine(medarbejderCollection.Size());
		medarbejderCollection.AddElement(mekaniker.Cpr, mekaniker);
        Console.Out.WriteLine(medarbejderCollection.Size());
        medarbejderCollection.AddElement(værkfører.Cpr, værkfører);
        Console.Out.WriteLine(medarbejderCollection.Size());
		medarbejderCollection.AddElement(synsmand.Cpr, synsmand);
        Console.Out.WriteLine(medarbejderCollection.Size());
	}
}