using Spotify.Domain.Abstract;

namespace Spotify.Domain.Response
{
    public class Artist
    {
        public string[] genres { get; set; }
        public string id { get; set; }
        public Image[] images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public Track[] topTracks { get; set; }
    }


}
