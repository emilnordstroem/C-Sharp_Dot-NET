
public class Program
{
    static void Main(string[] args)
    {
		EvenIntegers();
        Console.WriteLine("==================================");
		EvenIntegersLINQ();
		Console.WriteLine("==================================");

		IntegersAbove15();
        Console.WriteLine("==================================");

		IndexOfLastElementAbove15();
		Console.WriteLine("==================================");

		IntegersOfExactlyTwoDigits();
		Console.WriteLine("==================================");
	}

	private static void EvenIntegers()
    {
		List<int> integers = new List<int> { 6, 10, 2, 5, 3, 9, 7, 1, 4, 8 };
		IEnumerable<int> result = integers.Where(IsEven);
		integers = result.ToList();
		Print(integers);
	}

	private static void EvenIntegersLINQ()
	{
		List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		
		IEnumerable<int> queryExpression =
			from integer in integers
			where IsEven(integer)
			select integer;
		Print(queryExpression.ToList());
		IEnumerable<int> queryMethod = integers.Where(IsEven);
		Print(queryMethod.ToList());
	}

	private static void IntegersAbove15()
	{
		List<int> integers = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
		IEnumerable<int> result = integers.Where(integer => integer > 15);
		integers = result.ToList();
		Print(integers);
	}

	private static void IndexOfLastElementAbove15()
	{
		List<int> integers = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
		IEnumerable<int> result = integers.Where(integer => integer > 15);
		integers = result.ToList();
		int indexOfLastElement = integers.IndexOf(integers.Last());
		Console.WriteLine(indexOfLastElement);
	}

	private static void IntegersOfExactlyTwoDigits()
	{
		List<int> integers = new List<int> { 3, 6, 21, 1, 10, 19, 5 };
		IEnumerable<int> queryExpression =
			from integer in integers
			where ContainsTwoDigits(integer)
			orderby integer
			select integer;
		Print(queryExpression.ToList());
		IEnumerable<int> queryMethod = integers.Where(ContainsTwoDigits).OrderBy(integer => integer);
		Print(queryMethod.ToList());
	}

	private static bool IsEven(int integer)
    {
        return integer % 2 == 0;
    }

	private static bool ContainsTwoDigits(int integer)
	{
		return integer.ToString().Length == 2;
	}

    private static void Print(List<int> integers)
    {
		integers.ForEach(integers => Console.WriteLine(integers));
	}


}
