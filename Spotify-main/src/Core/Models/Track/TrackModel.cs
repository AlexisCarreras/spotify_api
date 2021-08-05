namespace Spotify.Core.Models.Track
{
	public class TrackModel
	{
		public AlbumTrack album { get; set; }
		public Artist1Track[] artists { get; set; }
		public string[] available_markets { get; set; }
		public int disc_number { get; set; }
		public int duration_ms { get; set; }
		public bool _explicit { get; set; }
		public External_IdsTrack external_ids { get; set; }
		public External_Urls2Track external_urls { get; set; }
		public string href { get; set; }
		public string id { get; set; }
		public bool is_local { get; set; }
		public string name { get; set; }
		public int popularity { get; set; }
		public string preview_url { get; set; }
		public int track_number { get; set; }
		public string type { get; set; }
		public string uri { get; set; }
	}

	public class AlbumTrack
	{
		public string album_type { get; set; }
		public ArtistTrack[] artists { get; set; }
		public string[] available_markets { get; set; }
		public External_Urls external_urls { get; set; }
		public string href { get; set; }
		public string id { get; set; }
		public ImageModel[] images { get; set; }
		public string name { get; set; }
		public string release_date { get; set; }
		public string release_date_precision { get; set; }
		public int total_tracks { get; set; }
		public string type { get; set; }
		public string uri { get; set; }
	}

	public class External_Urls
	{
		public string spotify { get; set; }
	}

	public class ArtistTrack
	{
		public External_Urls1 external_urls { get; set; }
		public string href { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string uri { get; set; }
	}

	public class External_Urls1
	{
		public string spotify { get; set; }
	}
	public class External_IdsTrack
	{
		public string isrc { get; set; }
	}

	public class External_Urls2Track
	{
		public string spotify { get; set; }
	}

	public class Artist1Track
	{
		public External_Urls3Track external_urls { get; set; }
		public string href { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string uri { get; set; }
	}

	public class External_Urls3Track
	{
		public string spotify { get; set; }
	}

}

