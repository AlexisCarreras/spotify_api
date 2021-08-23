using Spotify.Core.Response;
using System.Collections.Generic;

namespace Spotify.Core.Interfaces
{
    public interface IAlbumBusiness
    {
        Album Album(string id);
        List<AlbumTrack> AlbumTracks(string id);
    }
}
