using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;

namespace Spotify.Domain.Interfaces
{
    public interface ISearchBusiness
    {
        List<SearchDTO> SearchArtist(string name, SearchEnum type);
        List<SearchDTO> SearchAlbum(string name, SearchEnum type);
        List<SearchDTO> SearchTrack(string name, SearchEnum type);
    }
}
