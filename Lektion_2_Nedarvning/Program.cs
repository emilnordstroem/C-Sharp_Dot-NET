
public class Program
{
	static void Main ()
	{
        Medarbejder medarbejder = new()
        {
            Navn = "Emil",
            Adresse = "Programmeringsvej 110"
        };
        Console.Out.WriteLine(medarbejder.ToString());
        
        Mekaniker mekaniker = new()
        {
            Navn = "Emil",
            Adresse = "Programmeringsvej 110",
            AarForSvendeProeve = 2026,
            Timeloen = 135
        };
		Console.Out.WriteLine(mekaniker.ToString());
		Console.Out.WriteLine($"Mekaniker er en Medarbejder: {mekaniker is Medarbejder}");

		Værkfører værkfører = new()
        {
            Navn = "Emil",
            Adresse = "Programmeringsvej 110",
            AarForSvendeProeve = 2026,
            Timeloen = 135,
            AarForUdnaevelse = 2026,
            UgeTillaeg = 35
        };
		Console.Out.WriteLine(værkfører.ToString());
		Console.Out.WriteLine($"Værkfører er en Mekaniker: {værkfører is Mekaniker}");

		Synsmand synsmand = new()
        {
            Navn = "Emil",
            Adresse = "Programmeringsvej 110",
            AarForSvendeProeve = 2026,
            Timeloen = 135,
            AntalSynPerUge = 60
        };
		Console.Out.WriteLine(synsmand.ToString());
		Console.Out.WriteLine($"Synsmand er en Mekaniker: {synsmand is Mekaniker}");

	}
}