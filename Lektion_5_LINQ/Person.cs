using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
	public Person (string name, int age, int weight, int score)
	{
		Name = name;
		Age = age;
		Weight = weight;
		Score = score;
		Accepted = false;
	}

	public Person(string data)
	{
		// Name, Age, Weight, Score  
		var L = data.Split(';');

		Name = L[0];
		Age = int.Parse(L[1]);
		Weight = int.Parse(L[2]);
		Score = int.Parse(L[3]);
		Accepted = false; //denne parameter bliver ikke indlæst, men skal bruges senere.
	}

	public string Name { get; set; }
	public int Age { get; set; }
	public int Weight { get; set; }
	public int Score { get; set; }
	public bool Accepted { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}\nAge: {Age}\nWeight: {Weight}\nScore: {Score}";
    }

	public static List<Person> ReadCSVFile(string filename)
	{
		List<Person> people = new List<Person>();
		using (var file = new StreamReader(filename))
		{
			string line;
			while ((line = file.ReadLine()) != null)
			{
				Person person = new Person(line);
				people.Add(person);
			}
		}
		return people;
	}
}
