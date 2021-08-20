using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Core.Request;
using Spotify.Core.Response;

namespace Spotify.Core.Interfaces
{
    public interface ISearchBusiness
    {
        List<SearchDTO> SearchArtist(string name, int offset);
        List<SearchDTO> SearchAlbum(string name, int offset);
        List<SearchDTO> SearchTrack(string name, int offset);

        Task<IEnumerable<SearchDTO>> SearchV2(SearchRequestv2 request);
    }
}
