namespace Spotify.Core.Response
{
    public class Artist
    {
        public string id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public ArtistTrack[] topTracks { get; set; }
        public ArtistAlbum[] albums { get; set; }
    }
}
