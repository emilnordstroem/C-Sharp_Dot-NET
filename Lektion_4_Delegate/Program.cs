

using System.Linq;
using Individuals;

public class Program
{

    static void Main(string[] args)
    {

        String text = "Hello, World!";
        
        bool responds = text.Lang();
        Console.Out.WriteLine(responds);
        responds = MyExtension.Lang(text);
		Console.Out.WriteLine(responds);

		responds = text.Lang(10);
		Console.Out.WriteLine(responds);
		responds = MyExtension.Lang(text, 10);
		Console.Out.WriteLine(responds);

        
        CalculateAndDisplay(10, 10, Add);
        CalculateAndDisplay(10, 10, Multiply);


        int factorial = Factorial(4);
		Console.Out.WriteLine(factorial);

		Console.Out.WriteLine(4.Factorial());
        int factorialInput = 4;
        factorial = factorialInput.Factorial();
		Console.Out.WriteLine(factorial);
        factorial = MyExtensionForInt.Factorial(factorialInput);
        Console.Out.WriteLine(factorial);

        int powerTo = Power(10, 1);
		Console.Out.WriteLine(powerTo);
        Console.Out.WriteLine(10.Power(2));


        List<Person> people = new List<Person>();
        people.Add(new Person(23, 60, "Emil"));
		people.Add(new Person(24, 50, "Benjamin"));
		people.Add(new Person(25, 40, "Mickey"));

		people.Sort(new ByAgeSorter());
        Console.Out.WriteLine(string.Join(",", people));
		people.Sort(new ByNameSorter());
		Console.Out.WriteLine(string.Join(",", people));
		people.Sort(new ByWeightSorter());
		Console.Out.WriteLine(string.Join(",", people));

		people.Sort(CompareByAge);
		Console.Out.WriteLine(string.Join(",", people));
		people.Sort(CompareByName);
		Console.Out.WriteLine(string.Join(",", people));
		people.Sort(CompareByWeight);
		Console.Out.WriteLine(string.Join(",", people));
	}

	private static void CalculateAndDisplay(int a, int b, Operation operation)
    {
		Console.Out.WriteLine($"A: {a} \nB: {b}");
        var result = operation(a, b);
		Console.Out.WriteLine($"Calculated Result: {result}");
	}
    private static int Add(int a, int b)
    {
        return a + b;
    }
    private static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Factorial(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        return n * Factorial(n - 1);
    }

    public static int Power(int n, int p)
    {
        if (p <= 0)
        {
            return n; 
        }
        return n * Power(n, p - 1);
    }


	public static int CompareByAge(Person a, Person b)
	{
		return a.Age.CompareTo(b.Age);
	}
	public static int CompareByWeight(Person a, Person b)
	{
		return a.Weight.CompareTo(b.Weight);
	}
	public static int CompareByName(Person a, Person b)
	{
		return a.Name.CompareTo(b.Name);
	}

}

public static class MyExtension
{
    public static bool Lang(this String text)
    {
        return text.Length > 5;
    }

	public static bool Lang(this String text, int n)
	{
		return text.Length > n;
	}
}

public delegate int Operation(int a, int b);

public static class MyExtensionForInt
{
	public static int Factorial(this int n)
	{
		if (n <= 1)
		{
			return n;
		}
		return n * Factorial(n - 1);
	}

	public static int Power(this int n, int p)
	{
		if (p <= 0)
		{
			return n;
		}
		return n * Power(n, p - 1);
	}

}
