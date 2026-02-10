namespace Lektion_6_MVC.Models
{
    public class Book : Product
    {
        public Book(string name, string author, string publisher, short published, string isbn, double price) : base(name, price)
        {
            Author = author;
            Publisher = publisher;
            Published = published;
            ISBN = isbn;
        }

        public Book(string name, string author, string publisher, short published, string isbn, double price, string imageUrl) : base(name, price, imageUrl)
        {
			Author = author;
			Publisher = publisher;
			Published = published;
			ISBN = isbn;
		}

        public string Author { get; set; }
        public string Publisher { get; set; }
        public short Published { get; set; }
        public string ISBN { get; set; }

    }
}
