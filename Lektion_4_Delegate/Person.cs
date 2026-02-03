using System;
using System.Collections.Generic;
using System.Text;

namespace Individuals
{
	public class Person
	{
		public Person(int age, double weight, string name)
		{
			Age = age;
			Weight = weight;
			Name = name;
		}

		public int Age { get; set; }
		public double Weight { get; set; }
		public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} is {Age} years old and weights {Weight}";
        }
	}

    public class ByAgeSorter : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
			return a.Age.CompareTo(b.Age);
        }
    }

    public class ByWeightSorter : IComparer<Person>
	{
		public int Compare(Person a, Person b)
		{
			return a.Weight.CompareTo(b.Weight);
		}
	}

	public class ByNameSorter : IComparer<Person>
	{
		public int Compare(Person a, Person b)
		{
			return a.Name.CompareTo(b.Name);
		}
	}

	public delegate int SortBy (Person a, Person b);


}