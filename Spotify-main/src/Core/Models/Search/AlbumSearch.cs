//respuesta de consulta por album a API search/album

namespace Spotify.Core.Models.Search
{
    public class AlbumSearch : Abstract.Search
    {
        public Albums albums { get; set; }
    }

    public class Albums
    {
        public string href { get; set; }
        public ItemAlbumSearch[] items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class ItemAlbumSearch
    {
        public string album_type { get; set; }
        public ArtistAlbumSearch[] artists { get; set; }
        public string[] available_markets { get; set; }
        public External_UrlsAlbumSearch external_urls { get; set; }
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

    public class External_UrlsAlbumSearch
    {
        public string spotify { get; set; }
    }

    public class ArtistAlbumSearch
    {
        public External_Urls1AlbumSearch external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls1AlbumSearch
    {
        public string spotify { get; set; }
    }
}

