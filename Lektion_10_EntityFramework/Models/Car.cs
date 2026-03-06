namespace Lektion_10_EntityFramework.Models
{
	public class Car
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }

		public Car()
		{
		}

		public Car(string brand, string model)
		{
			Brand = brand;
			Model = model;
		}

		public override string ToString()
		{
			return $"{Brand} {Model}";
		}
	}
}
