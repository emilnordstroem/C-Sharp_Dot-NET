namespace Lektion_10_EntityFramework.Models
{
	public class Car
	{
		public int CarId { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int OwnerId { get; set; }
		public Owner Owner { get; set; }

		public Car()
		{
		}

		public Car(string brand, string model, int year, Owner owner)
		{
			Brand = brand;
			Model = model;
			Year = year;
			OwnerId = owner.OwnerId;
			Owner = owner;
		}
	}
}
