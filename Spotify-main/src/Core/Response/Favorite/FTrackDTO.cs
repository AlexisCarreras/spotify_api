using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Core.Response.Favorite
{
    public class FTrackDTO
    {
        public string AlbumIdSpotify { get; set; }
        public string TrackIdSpotify { get; set; }
        public string ArtistIdSpotify { get; set; }
        public string TrackName { get; set; }
    }
}
