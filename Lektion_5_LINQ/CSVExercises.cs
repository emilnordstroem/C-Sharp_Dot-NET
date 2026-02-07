using System;
using System.Collections.Generic;
using System.Text;

public class CSVExercises
{
	static void Main(string[] args)
	{
		List<Person> people = GetPeopleFrom("data1");

		Print(
			"Score Below 2", 
			PeopleWithScoreBelow(people, 2)
		);
		Print(
			"Even Score", 
			PeopleWithEvenScore(people)
		);
		Print(
			"Even Score and Weight Above 60", 
			PeopleWithEvenScoreAndWeightAbove(people, 60)
		);
		Print(
			"Wight Distribution on 3", 
			PeopleWithWeightDistributionOn(people, 3)
		);


		Print(
			"Index Score of 3", 
			IndexOfFirstPersonWithScoreOf(people, 3)
		);
		Print(
			"Index Age Above 10 and Score of 3", 
			IndexOfFirstPersonAboveAgeAndWithAScoreOf(people, 10, 3)
		);
		Print(
			"Number of People with Age Under 10 and Score of 3", 
			AmountOfPeopleUnderAgeAndWithScoreOf(people, 10, 3)
		);
		Print(
			"Indexes Age Under 8 and Score of 3", 
			IndexOfFirstPersonUnderAgeAndWithScoreOf(people, 8, 3)
		);

		Predicate<Person> predicate = person => person.Score > 5;
		people.SetAcceptedPerson(predicate);

		Print(
			"Sorted By Score Ascending", 
			SortPeopleByScoreAsc(people)
		);
		Print(
			"Sorted By Score Descending",
			SortPeopleByScoreDesc(people)
		);
		Print(
			"Sorted By Age Ascending",
			SortPeopleByAgeAsc(people)
		);
		Print(
			"Sorted By Age Descending",
			SortPeopleByAgeDesc(people)
		);

		people.Reset();

		// Task 5.10
		List<int> integers = new List<int>();

		Random random = new Random();
		int limit = 100;
		while (limit > 0)
		{
			integers.Add(random.Next(1, 101));
			limit--;
		}
		Print(
			"Number of Uneven Integers",
			NumberOfUnevenIntegers(integers)
		);
		Print(
			"Number of Unique Integers",
			NumberOfUniqueIntegers(integers)
		);
		Print(
			"First Three Uneven Integers",
			FirstXUnevenIntegers(integers, 3)
		);
		Print(
			"All Unique Uneven Integers",
			AllUniqueUnevenIntegers(integers)
		);
	}

	private static List<Person> GetPeopleFrom(string filename)
	{
		try
		{
			List<Person> people = Person.ReadCSVFile($@"C:\Projects\VisualStudio\repos\C-Sharp_and_DOT-NET_Lecture_Exercises\Lektion_5_LINQ\{filename}.csv");
			return people;
		}
		catch (Exception ex)
		{
			Console.WriteLine("EXCEPTION: " + ex.Message);
			Console.WriteLine("You should probably set the filename to the Person.ReadCSVFile method to something on your disk!");
			return new List<Person>();
		}
	}

	private static List<Person> PeopleWithScoreBelow(List<Person> people, int scoreRoof)
	{
		return people.FindAll(person => person.Score < scoreRoof);
	}
	private static List<Person> PeopleWithEvenScore(List<Person> people)
	{
		return people.FindAll(person => person.Score % 2 == 0);
	}
	private static List<Person> PeopleWithEvenScoreAndWeightAbove(List<Person> people, int baseWeight)
	{
		return people.FindAll(person => person.Score % 2 == 0 && person.Weight > baseWeight);
	}
	private static List<Person> PeopleWithWeightDistributionOn(List<Person> people, int weight)
	{
		return people.FindAll(person => person.Weight % 3 == 0);
	}

	private static int IndexOfFirstPersonWithScoreOf(List<Person> people, int baseScore)
	{
		return people.FindIndex(person => person.Score == baseScore);
	}
	private static int IndexOfFirstPersonAboveAgeAndWithAScoreOf(List<Person> people, int aboveAge, int score)
	{
		return people.FindIndex(person => person.Age > aboveAge && person.Score == score);
	}
	private static int AmountOfPeopleUnderAgeAndWithScoreOf(List<Person> people, int belowAge, int score)
	{
		return people.FindAll(person => person.Age < belowAge && person.Score == score).Count();
	}
	private static int IndexOfFirstPersonUnderAgeAndWithScoreOf(List<Person> people, int belowAge, int score)
	{
		return people.FindIndex(person => person.Age < belowAge && person.Score == score);
	}

	private static List<Person> SortPeopleByScoreAsc(List<Person> people)
	{
		return people.OrderBy(person => person.Score).ToList();
	}
	private static List<Person> SortPeopleByScoreDesc(List<Person> people)
	{
		return people.OrderByDescending(person => person.Score).ToList();
	}
	private static List<Person> SortPeopleByAgeAsc(List<Person> people)
	{
		return people.OrderBy(person => person.Age).ToList();
	}
	private static List<Person> SortPeopleByAgeDesc(List<Person> people)
	{
		return people.OrderByDescending(person => person.Age).ToList();
	}

	private static int NumberOfUnevenIntegers(List<int> integers)
	{
		return integers.Where(integer => integer % 2 != 0).Count();
	}
	private static int NumberOfUniqueIntegers(List<int> integers)
	{
		return integers.Distinct().Count();
	}
	private static List<int> FirstXUnevenIntegers(List<int> integers, int amount)
	{
		return integers.Where(integer => integer % 2 != 0).Take(3).ToList();
	}
	private static List<int> AllUniqueUnevenIntegers(List<int> integers)
	{
		return integers.Where(integer => integer % 2 != 0).Distinct().ToList();
	}


	private static void Print(string message, List<Person> people)
	{
		Console.WriteLine("============================");
		Console.WriteLine(message);
		people.ForEach(person => Console.WriteLine($"{person.ToString()}\n"));
	}
	private static void Print(string message, int value)
	{
		Console.WriteLine("============================");
		Console.WriteLine(message);
		Console.WriteLine(value);
	}
	private static void Print(string message, List<int> people)
	{
		Console.WriteLine("============================");
		Console.WriteLine(message);
		people.ForEach(integer => Console.WriteLine($"{integer}\n"));
	}

}

public static class PersonExtension
{
	public static void SetAcceptedPerson(this List<Person> list, Predicate<Person> predicate)
	{
		list.FindAll(predicate).ForEach(person => person.Accepted = true);

		Console.WriteLine("============================");
		Console.WriteLine("All That Were Accepted:");
		list.ForEach(person => Console.WriteLine($"{person.ToString()}\n"));
	}

	public static void Reset(this List<Person> list)
	{
		Console.WriteLine("============================");
		Console.WriteLine("Reset All People...");
		list.ForEach(person => person.Accepted = false);
		list.ForEach(person => Console.WriteLine($"{person.ToString()}\n"));
	}

}
