
public class LINQExercises
{
    static void Main(string[] args)
    {
		EvenIntegers();
		EvenIntegersLINQ();
		IntegersAbove15();
		IndexOfLastElementAbove15();
		IntegersOfExactlyTwoDigits();

		int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };
		SortNumbersAscending(numbers);
		SortNumbersDescending(numbers);
		SortNumbersAscendingString(numbers);
		EvenUnevenNumbers(numbers);
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

	private static void SortNumbersAscending(int[] numbers)
	{
		IEnumerable<int> result = numbers.Where(ContainsTwoDigits).OrderBy(number => number);
		Print(result.ToList());
	}
	private static void SortNumbersDescending(int[] numbers)
	{
		IEnumerable<int> result = numbers.Where(ContainsTwoDigits).OrderByDescending(number => number);
		Print(result.ToList());
	}
	private static void SortNumbersAscendingString(int[] numbers)
	{
		IEnumerable<string> result = numbers
			.Where(ContainsTwoDigits)
			.OrderBy(number => number)
			.Select(number => number.ToString());
		Print(result.ToList());
    }
	private static void EvenUnevenNumbers(int[] numbers)
	{
		IEnumerable<string> result = numbers
			.Where(ContainsTwoDigits)
			.OrderByDescending(number => number)
			.Select(number => IsEven(number) ? $"{number.ToString()} even" : $"{number.ToString()} uneven");
		Print(result.ToList());
	}

    private static void Print(List<int> input)
    {
		Console.WriteLine("==================================");
		input.ForEach(integers => Console.WriteLine(integers));
	}
	private static void Print(List<string> input)
	{
		Console.WriteLine("==================================");
		input.ForEach(integers => Console.WriteLine(integers));
	}

}