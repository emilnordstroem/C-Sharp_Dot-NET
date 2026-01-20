namespace MyLibrary {
	public interface IAnimal
	{
		bool IsDog();
	}

	public class Animal : IAnimal
	{
		private string specie;
		public Animal(string specie)
		{
			this.specie = specie;
		}
		public bool IsDog()
		{
			return specie.ToLower() == "dog";
		}
	}
}

