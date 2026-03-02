using System.ComponentModel.DataAnnotations.Schema;

namespace Lektion_10_EntityFramework.Models
{
	[Table("Bil")]
	public class Bil
	{
		public int BilID { get; set; } // becomes a primary key
		public string Name { get; set; }
		public int Weight { get; set; }
		public bool Diesel { get; set; }

		public Bil()
		{

		}
		public Bil(string name, int weight)
		{
			Name = name;
			Weight = weight;
		}

	}
}
