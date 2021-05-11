using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Models
{
	public class ArtistTopTracks
	{
		public Track[] tracks { get; set; }
	

		public class Track
		{
			public Album album { get; set; }
			public Artist1[] artists { get; set; }
			public int disc_number { get; set; }
			public int duration_ms { get; set; }
			public bool _explicit { get; set; }
			public External_Ids external_ids { get; set; }
			public External_Urls2 external_urls { get; set; }
			public string href { get; set; }
			public string id { get; set; }
			public bool is_local { get; set; }
			public bool is_playable { get; set; }
			public string name { get; set; }
			public int popularity { get; set; }
			public string preview_url { get; set; }
			public int track_number { get; set; }
			public string type { get; set; }
			public string uri { get; set; }
		}

		public class Album
		{
			public string album_type { get; set; }
			public Artist[] artists { get; set; }
			public External_Urls external_urls { get; set; }
			public string href { get; set; }
			public string id { get; set; }
			public Image[] images { get; set; }
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

		public class Artist
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

		public class Image
		{
			public int height { get; set; }
			public string url { get; set; }
			public int width { get; set; }
		}

		public class External_Ids
		{
			public string isrc { get; set; }
		}

		public class External_Urls2
		{
			public string spotify { get; set; }
		}

		public class Artist1
		{
			public External_Urls3 external_urls { get; set; }
			public string href { get; set; }
			public string id { get; set; }
			public string name { get; set; }
			public string type { get; set; }
			public string uri { get; set; }
		}

		public class External_Urls3
		{
			public string spotify { get; set; }
		}

	}
}
