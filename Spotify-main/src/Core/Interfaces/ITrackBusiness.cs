using Spotify.Core.Response;
using System.Threading.Tasks;

namespace Spotify.Core.Interfaces
{
    public interface ITrackBusiness
    {
        Task<Track> Track(string id);
        Task<TrackFeature> TrackFeature(string id);
    }
}
