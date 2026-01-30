using System;
using System.Collections.Generic;
using System.Text;

var input = Console.ReadLine();
int inputNumber = int.Parse(input); 

static List<int> FibonacciNumbers(List<int> fibonacciNumbers, int index, int baseCondition)
{
	if (fibonacciNumbers.Count >= baseCondition)
	{
		return fibonacciNumbers;
	} 
	else if (index <= 1)
	{
		fibonacciNumbers.Add(index);
	} 
	else
	{
		fibonacciNumbers.Add(fibonacciNumbers[index - 1] + fibonacciNumbers[index - 2]);
	}
	return FibonacciNumbers(fibonacciNumbers, index + 1, baseCondition);
}

var fibonacciNumbers = FibonacciNumbers(new List<int>(), 0, inputNumber);
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