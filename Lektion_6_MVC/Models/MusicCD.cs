namespace Lektion_6_MVC.Models
{
    public class MusicCD : Product
    {
        public MusicCD(string name, string artist, string label, short released, List<Track> tracks, double price) : base(name, price)
        {
            Artist = artist;
            Label = label;
            Released = released;
            Tracks = tracks;
        }

        public MusicCD(string name, string artist, string label, short released, List<Track> tracks, double price, string imageUrl) : base(name, price, imageUrl)
        {
			Artist = artist;
			Label = label;
			Released = released;
			Tracks = tracks;
		}

        public string Artist { get; set; }
        public string Label { get; set; }
        public short Released { get; set; }
        public List<Track> Tracks { get; set; }

        public void AddTrack (Track track)
        {
            if (!Tracks.Contains(track))
            {
                Tracks.Add(track);
            }
        }
        public TimeSpan GetPlayingTime()
        {
            TimeSpan totalPlayingTime = new TimeSpan();
            foreach (Track track in Tracks)
            {
                totalPlayingTime += TimeSpan.Parse(track.Length);
            }
            return totalPlayingTime;
        }
    }
}
