
namespace Lektion_6_MVC.Models {
	public class Product
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private double price;
		public double Price
		{
			set
			{
				if (value <= 0)
				{
					throw new Exception("Price is not accepted");
				}
				else
				{
					price = value;
				}
			}
			get { return price; }
		}

		private string imageUrl;
		public string ImageUrl
		{
			get { return imageUrl; }
			set { imageUrl = value; }
		}

		public Product(string name, double price)
		{
			this.name = name;
			this.price = price;
		}

		public Product(string name, double price, string imageUrl)
		{
			this.name = name;
			this.price = price;
			this.imageUrl = imageUrl;
		}
	}
}
