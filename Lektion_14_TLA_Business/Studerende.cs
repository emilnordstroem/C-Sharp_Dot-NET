namespace Lektion_14_TLA_Business
{
	public class Studerende
	{
		public Guid? Id { get; set; }
		public string Navn { get; set; }
		public DateTime StudieStart { get; set; }
		public int Alder { get; set; }
		public Guid? HoldId { get; set; }
		public Hold? Hold { get; set; }
		public Uddannelse Uddannelse { get; set; }
		public UddannelsesNiveau Niveau { get; set; }
		
		public Studerende () { }

	}

	public enum Uddannelse 
	{
		Datamatiker,
		Datalogi,
		Softwareteknologi,
		Softwareudvikler
	}

	public enum UddannelsesNiveau
	{
		Erhvervsakademiuddannelse,
		Professionsbachelor,
		Bachelor,
		Kandidat,
		PHD
	}

}
