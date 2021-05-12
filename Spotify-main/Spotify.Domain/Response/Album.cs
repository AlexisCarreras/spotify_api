using Spotify.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Response
{
    public class Album
    {
        public string id { get; set;  }
        public string name { get; set; }
        public Image[] images { get; set; }
        public string type { get; set; }
        public Track[] tracks { get; set; }
        public int totalTracks { get; set; }
        public string albumArtist { get; set; } // albums{items[artist[i].name]}
    }
}