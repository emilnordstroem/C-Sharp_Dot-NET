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


int age;
static void CalculateAge(DateTime BirthDateInput, out int age)
{
	if (DateTime.Compare(DateTime.Now, BirthDateInput) < 0)
	{
		age = DateTime.Now.Year - BirthDateInput.Year;
	} 
	else
	{
		age = (DateTime.Now.Year - BirthDateInput.Year) - 1;
	}
}
CalculateAge(new DateTime(2002, 12, 13), out age);
Console.Out.WriteLine(age);


static void MyMethodWithError(int num = 0)
{
	throw new Exception();
}

static void MyNormalMethod(int num = 0)
{
	try
	{
		MyMethodWithError();
	}
	catch 
	{
		Console.Out.WriteLine("Error was caught");
	}
	finally
	{
		Console.Out.WriteLine("Executed although an Error was caught");
	}
}

MyNormalMethod();

