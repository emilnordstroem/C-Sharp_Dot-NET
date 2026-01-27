using System;
using System.Collections.Generic;
using System.Text;

var input = Console.ReadLine();
int inputNumber = int.Parse(input);

static List<int> FibonacciNumbers(List<int> fibonacciNumbers, int baseCondition)
{
	if (fibonacciNumbers.Count >= baseCondition)
	{
		return fibonacciNumbers;
	} 
	else if (fibonacciNumbers.Count == 0)
	{
		fibonacciNumbers.Add(0);
		fibonacciNumbers.Add(1);
	}

	int nextFibonacciNumber = fibonacciNumbers[fibonacciNumbers.Count - 2] + fibonacciNumbers.Last();
	fibonacciNumbers.Add(nextFibonacciNumber);
	return FibonacciNumbers(fibonacciNumbers, baseCondition);
}

var fibonacciNumbers = FibonacciNumbers(new List<int>(), inputNumber);
Console.Out.WriteLine(string.Join(", ", fibonacciNumbers));



