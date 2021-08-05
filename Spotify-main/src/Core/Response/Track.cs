namespace Spotify.Core.Response
{
    public class Track
    {
        public string name { get; set; }
        public string id { get; set; }
		public Image[] images { get; set; }
		public string type { get; set; }
        public int trackLength { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        public string previewUrl { get; set; }
        public bool favorite { get; set; }
		public float danceability { get; set; }
		public float energy { get; set; }
		public int key { get; set; }
		public int mode { get; set; }
		public float speechiness { get; set; }
		public float acousticness { get; set; }
		public float instrumentalness { get; set; }
		public float liveness { get; set; }
		public float valence { get; set; }
		public float tempo { get; set; }
	}
}
