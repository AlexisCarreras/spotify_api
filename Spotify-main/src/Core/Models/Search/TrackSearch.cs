//respuesta de consulta por track a API search/track

namespace Spotify.Core.Models.Search
{
    public class TrackSearch : Abstract.Search
    {
        public Tracks tracks { get; set; }
    }

        public class Tracks
        {
            public string href { get; set; }
            public ItemTrackSearch[] items { get; set; }
            public int limit { get; set; }
            public string next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total { get; set; }
        }

        public class ItemTrackSearch
        {
            public AlbumTrackSearch album { get; set; }
            public Artist1[] artists { get; set; }
            public string[] available_markets { get; set; }
            public int disc_number { get; set; }
            public int duration_ms { get; set; }
            public bool _explicit { get; set; }
            public External_Ids external_ids { get; set; }
            public External_Urls2 external_urls { get; set; }
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

        public class AlbumTrackSearch
        {
            public string album_type { get; set; }
            public ArtistTrackSearch[] artists { get; set; }
            public string[] available_markets { get; set; }
            public External_UrlsTrackSearch external_urls { get; set; }
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

        public class External_UrlsTrackSearch
        {
            public string spotify { get; set; }
        }

        public class ArtistTrackSearch
        {
            public External_Urls1TrackSearch external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls1TrackSearch
        {
            public string spotify { get; set; }
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
