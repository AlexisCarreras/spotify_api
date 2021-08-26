using Featurify.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Featurify.Core.Interfaces
{
    public interface IArtistBusiness
    {
        Task<Artist> artist(string id);
        Task<IEnumerable<ArtistAlbum>> ArtistAlbums(string id, int offset);
        Task<IEnumerable<ArtistTrack>> ArtistTopTracks(string id, string market);
    }
}
