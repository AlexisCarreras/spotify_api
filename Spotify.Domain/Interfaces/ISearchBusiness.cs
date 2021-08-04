using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;

namespace Spotify.Domain.Interfaces
{
    public interface ISearchBusiness
    {
        List<Artist> SearchArtist(string name, SearchEnum type);
        List<Album> SearchAlbum(string name, SearchEnum type);
        List<Track> SearchTrack(string name, SearchEnum type);
    }
}
