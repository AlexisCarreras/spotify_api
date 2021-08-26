using Featurify.Core.Response;
using System.Threading.Tasks;

namespace Featurify.Core.Interfaces
{
    public interface ITrackBusiness
    {
        Task<Track> Track(string id);
        Task<TrackFeature> TrackFeature(string id);
    }
}
