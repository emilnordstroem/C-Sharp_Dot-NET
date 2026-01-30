
using C_Sharp_and_DOT_NET_Lecture_Exercises.personNamespace;
using MyLibrary;

class Lektion_1_Introduktion
{
	static void Main(string[] args)
	{
		Person person = new Person("Emil");
		person.Age = 23;
		Console.WriteLine(person);
		person.Name = "Maria";
		Console.WriteLine(person);

		Console.WriteLine("Which animal specie would you like to create?");
		string specie;
		specie = Console.ReadLine();
		Animal dusty = new Animal(specie);
		Console.WriteLine("Are the animal specie 'dog'? - {0}", dusty.IsDog());

		MyList myList = new MyList();
		myList.AddNumber(1);
		myList.AddNumber(2);
		myList.AddNumber(3);
		myList.AddNumber(4);
		myList.AddNumber(5);
		myList.PrintNumbers();

		myList = new MyList();
		var randomNumber = new Random();
		for (int counter = 1; counter <= 10; counter++)
		{
			myList.AddNumber(randomNumber.Next(1, 101));
		}
		myList.PrintNumbers();

	}
}

class MyList
{
	private List<int> liste = new List<int>();
	public MyList () {}
	public void AddNumber (int number)
	{
		liste.Add(number);
	}
	public void PrintNumbers ()
	{
		foreach (int number in liste)
		{
			Console.WriteLine(number);
		}
	}
}

