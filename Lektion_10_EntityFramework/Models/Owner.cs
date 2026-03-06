namespace Lektion_10_EntityFramework.Models
{
	public class Owner
	{
		public int OwnerId { get; set; }
		public string Name { get; set; }
		
		public Owner()
		{
		}

		public Owner(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}
