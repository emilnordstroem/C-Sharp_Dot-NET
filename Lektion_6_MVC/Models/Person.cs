namespace Lektion_6_MVC.Models
{
    public class Person
    {
        public Person(string name, int age, DateTime birthday)
        {
            Name = name;
            Age = age;
            Birthday = birthday;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}
