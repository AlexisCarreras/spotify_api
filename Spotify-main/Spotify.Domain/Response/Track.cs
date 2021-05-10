using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Response
{
    public class Track
    {
        public string name { get; set; }
        public string id { get; set; }
        public int trackLength { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        public string previewUrl { get; set; }

    }
}
