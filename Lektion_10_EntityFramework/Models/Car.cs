namespace Lektion_10_EntityFramework.Models
{
	public class Car
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public Car()
		{
		}

		public Car(string brand, string model, int year)
		{
			Brand = brand;
			Model = model;
			Year = year;
		}

		public override string ToString()
		{
			return $"{Brand} {Model}";
		}
	}
}
