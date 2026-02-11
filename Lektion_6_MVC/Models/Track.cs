namespace Lektion_6_MVC.Models
{
    public class Track
    {
        public Track (string title, string composer, string length)
        {
            Title = title;
            Composer = composer;
            Length = length;
        }

        public string Title { get; set; }
        public string Composer { get; set; }
        public string Length { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Composer}) {Length}";
        }
    }
}
