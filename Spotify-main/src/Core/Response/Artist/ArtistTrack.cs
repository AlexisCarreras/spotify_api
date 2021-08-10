namespace Spotify.Core.Response
{
	public class ArtistTrack
	{
		public string name { get; set; }
		public string id { get; set; }
		public string type { get; set; }
		public int trackLength { get; set; }
		public string albumName { get; set; }
		public string previewUrl { get; set; }
		public bool favorite { get; set; }
	}
}
