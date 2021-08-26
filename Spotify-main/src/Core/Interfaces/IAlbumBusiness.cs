using Spotify.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Core.Interfaces
{
    public interface IAlbumBusiness
    {
        Task<Album> Album(string id);
        List<AlbumTrack> AlbumTracks(string id);
    }
}
