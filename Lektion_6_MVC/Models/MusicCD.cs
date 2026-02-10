namespace Lektion_6_MVC.Models
{
    public class MusicCD : Product
    {
        public MusicCD(string name, string artist, string label, short released, List<string> tracks, double price) : base(name, price)
        {
            Artist = artist;
            Label = label;
            Released = released;
            Tracks = tracks;
        }

        public MusicCD(string name, string artist, string label, short released, List<string> tracks, double price, string imageUrl) : base(name, price, imageUrl)
        {
			Artist = artist;
			Label = label;
			Released = released;
			Tracks = tracks;
		}

        public string Artist { get; set; }
        public string Label { get; set; }
        public short Released { get; set; }
        public List<string> Tracks { get; set; }

        public void AddTrack (string track)
        {
            if (!Tracks.Contains(track))
            {
                Tracks.Add(track);
            }
        }
    }
}
