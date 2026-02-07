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

}
