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
		public string? Name { get; set; }
		public int? Age { get; set; }
		public DateTime? Birthday { get; set; }


        private DateTime birthdate;
        public Person(string firstnavn, string lastnavn, string address, string zip, string city, List<string> phoneNumbers)
        {
            FirstName = firstnavn;
            LastName = lastnavn;
            Address = address;
            Zip = zip;
            City = city;
            PhoneNumbers = phoneNumbers;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
		public string? Zip { get; set; }
		public string? City { get; set; }
        public List<string>? PhoneNumbers { get; set; }
        public void AddPhoneNumber (string phoneNumber)
        {
            if (!PhoneNumbers.Contains(phoneNumber))
            {
                PhoneNumbers.Add(phoneNumber);
            }
        }
		public DateTime Birthdate
        {
            set
            {
                if (birthdate.CompareTo(DateTime.Now) > 0)
                {
                    throw new Exception("Age not Accepted");
                }
                else
                {
                    birthdate = value;
                }
            }
            get
            {
                return birthdate;
            }
        }
        public int CalculateAge ()
        {
			DateTime now = DateTime.Now;
			int age;
			age = now.Year - Birthdate.Year;
			// calculate to see if the person hasn’t had birthday yet 
			// subtract one year if that is not the case 
			if (now.Month < Birthdate.Month || (now.Month == Birthdate.Month
			&& now.Day < Birthdate.Day))
			{
				age--;
			}
            return age;
		}
	}
}
