namespace Lektion_14_TLA_DTO
{
	public class StuderendeDTO
	{
		public string Navn { get; set; }
		public DateTime StudieStart { get; set; }
		public int Alder { get; set; }
		public string Hold { get; set; }
		public string Uddannelse { get; set; }
		public string Niveau { get; set; }
		
		public StuderendeDTO () { }

		public override string ToString()
		{
			return $"{Navn}, {Alder} år ({Hold})\nStudie start: {StudieStart.ToLocalTime()}\n{Niveau} i {Uddannelse}";
		}

	}

}
