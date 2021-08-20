using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Core.Response
{
    public class TrackFeature
    {
		public int danceability { get; set; }
		public int energy { get; set; }
		public int speechiness { get; set; }
		public int acousticness { get; set; }
		public int instrumentalness { get; set; }
		public int liveness { get; set; }
		public int valence { get; set; }
		public string key { get; set; }
		public string mode { get; set; }
		public float tempo { get; set; }
	}
}
