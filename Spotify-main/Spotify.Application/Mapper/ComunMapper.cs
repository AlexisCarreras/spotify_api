using Spotify.Domain.Models.Track;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;


namespace Spotify.Application.Mapper
{
	public static class ComunMapper
	{
		public static void TrackMapping(this Track destino, TrackFeaturesModel Origen)
		{
            if (Origen != null)
            {
                destino.acousticness = Origen.acousticness;
                destino.danceability = Origen.danceability;
                destino.energy = Origen.energy;
                destino.instrumentalness = Origen.instrumentalness;
                destino.key = Origen.key;
                destino.liveness = Origen.liveness;
                destino.mode = Origen.mode;
                destino.speechiness = Origen.speechiness;
                destino.tempo = Origen.tempo;
                destino.valence = Origen.valence;
            }
        }
	}
}
