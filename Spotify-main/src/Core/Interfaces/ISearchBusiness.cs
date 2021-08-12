using System.Collections.Generic;
using Spotify.Core.Enums;
using Spotify.Core.Response;

namespace Spotify.Core.Interfaces
{
    public interface ISearchBusiness
    {
        List<SearchDTO> SearchArtist(string name, SearchEnum type, int offset);
        List<SearchDTO> SearchAlbum(string name, SearchEnum type, int offset);
        List<SearchDTO> SearchTrack(string name, SearchEnum type, int offset);
    }
}
