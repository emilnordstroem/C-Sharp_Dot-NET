using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_and_DOT_NET_Lecture_Exercises.personNamespace
{
	internal class Person
    {
        private string name;
        private int age;
        public Person(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public override string ToString()
        {
            return $"My name is {name}, and I am {age} years old.";
        }
    }
}
