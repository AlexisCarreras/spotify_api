using Spotify.Core.Models.Track;
using Spotify.Core.Response;

namespace Spotify.Business.Mapper
{
    public static class TrackFeaturesMapper
	{
        public static void TrackMapping(this Track destino, TrackFeaturesModel Origen)
        {
            string[] keys = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] mode = { "Menor", "Mayor" };

            if (Origen != null)
            {
                destino.acousticness = (int)(Origen.acousticness*1000);
                destino.danceability = (int)(Origen.danceability*1000);
                destino.energy = (int)(Origen.energy*1000);
                destino.instrumentalness = (int)(Origen.instrumentalness*1000);
                destino.liveness = (int)(Origen.liveness*1000);
                destino.speechiness = (int)(Origen.speechiness*1000);
                destino.valence = (int)(Origen.valence*1000);
                destino.key = keys[Origen.key];
                destino.mode = mode[Origen.mode];
                destino.tempo = Origen.tempo;
            }
        }
	}
}
