//respuesta de consulta de album por artista a API artist/{idDeartista}/albums

namespace Spotify.Core.Models.Artist
{
	public class AlbumArtist
	{
			public string href { get; set; }
			public ItemAlbumArtist[] items { get; set; }
			public int limit { get; set; }
			public string next { get; set; }
			public int offset { get; set; }
			public object previous { get; set; }
			public int total { get; set; }

		public class ItemAlbumArtist
		{
			public string album_group { get; set; }
			public string album_type { get; set; }
			public ArtistAlbum[] artists { get; set; }
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

		public class ArtistAlbum
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

	}
}
