//respuesta de consulta por artista a API search/artist

namespace Spotify.Domain.Models.Search
{
    public class ArtistSearch : Spotify.Domain.Abstract.Search
    {
        public Artists artists { get; set; }
    }

    public class Artists
    {
        public string href { get; set; }
        public ItemArtistSearch[] items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class ItemArtistSearch
    {
        public External_UrlsArtistSearch external_urls { get; set; }
        public Followers followers { get; set; }
        public string[] genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public ImageModel[] images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_UrlsArtistSearch
    {
        public string spotify { get; set; }
    }

    public class Followers
    {
        public object href { get; set; }
        public int total { get; set; }
    }
}
