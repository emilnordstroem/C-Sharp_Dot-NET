namespace Lektion_10_EntityFramework.Models
{
	public class Bil
	{
		public int ID { get; set; }
		public string Navn { get; set; }
		public int Vaegt { get; set; }

		public Bil() {}

		public Bil(int id, string navn, int vaegt)
		{
			ID = id;
			Navn = navn;
			Vaegt = vaegt;
		}

		public override string ToString()
		{
			return $"{Navn} på {Vaegt} kg";
		}
	}
}
