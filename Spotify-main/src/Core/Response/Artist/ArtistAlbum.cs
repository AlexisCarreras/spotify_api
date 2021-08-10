namespace Spotify.Core.Response
{
    public class ArtistAlbum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public int totalTracks { get; set; }
        public string albumArtist { get; set; }
    }
}