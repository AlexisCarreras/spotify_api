using Spotify.Core.Response;
using System.Collections.Generic;

namespace Spotify.Core.Interfaces
{
    public interface IArtistBusiness
    {
        Artist artist(string id);
        List<ArtistAlbum> ArtistAlbums(string id, int offset);
        List<ArtistTrack> ArtistTopTracks(string id, string market);
    }
}
