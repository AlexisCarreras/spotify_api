using Spotify.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Core.Interfaces
{
    public interface IArtistBusiness
    {
        Task<Artist> artist(string id);
        Task<IEnumerable<ArtistAlbum>> ArtistAlbums(string id, int offset);
        Task<IEnumerable<ArtistTrack>> ArtistTopTracks(string id, string market);
    }
}
