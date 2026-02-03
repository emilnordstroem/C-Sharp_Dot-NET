

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

        int factorialInput = 4;
        factorial = factorialInput.Factorial();
		Console.Out.WriteLine(factorial);
        factorial = MyExtensionForInt.Factorial(factorialInput);
        Console.Out.WriteLine(factorial);



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
}