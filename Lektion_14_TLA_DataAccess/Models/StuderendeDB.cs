namespace Lektion_14_TLA_DataAccess
{
	internal class StuderendeDB
	{
		public Guid? Id { get; set; }
		public string Navn { get; set; }
		public DateTime StudieStart { get; set; }
		public int Alder { get; set; }
		public Guid? HoldId { get; set; }
		public HoldDB? Hold { get; set; }
		public Uddannelse Uddannelse { get; set; }
		public UddannelsesNiveau Niveau { get; set; }
		
		public StuderendeDB () { }

	}

	internal enum Uddannelse 
	{
		Datamatiker,
		Datalogi,
		Softwareteknologi,
		Softwareudvikler
	}

	internal enum UddannelsesNiveau
	{
		Erhvervsakademiuddannelse,
		Professionsbachelor,
		Bachelor,
		Kandidat,
		PHD
	}

}
