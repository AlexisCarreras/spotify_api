using Featurify.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Featurify.Core.Interfaces
{
    public interface IAlbumBusiness
    {
        Task<Album> Album(string id);
        Task<IEnumerable<AlbumTrack>> AlbumTracks(string id);
    }
}
