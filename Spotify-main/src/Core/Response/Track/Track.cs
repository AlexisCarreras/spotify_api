namespace Spotify.Core.Response
{
    public class Track
    {
        public string name { get; set; }
        public string id { get; set; }
		public string image { get; set; }
		public string type { get; set; }
        public string trackLength { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        public string previewUrl { get; set; }
		public int danceability { get; set; }
		public int energy { get; set; }
		public int speechiness { get; set; }
		public int acousticness { get; set; }
		public int instrumentalness { get; set; }
		public int liveness { get; set; }
		public int valence { get; set; }
		public string key { get; set; }
		public string mode { get; set; }
		public float tempo { get; set; }
		public bool favorite { get; set; }
	}
}
