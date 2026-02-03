

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