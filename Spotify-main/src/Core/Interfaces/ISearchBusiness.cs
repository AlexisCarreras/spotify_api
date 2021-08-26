using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Core.Request;
using Spotify.Core.Response;

namespace Spotify.Core.Interfaces
{
    public interface ISearchBusiness
    {
        Task<IEnumerable<SearchDTO>> SearchArtist(string name, int offset);
        Task<IEnumerable<SearchDTO>> SearchAlbum(string name, int offset);
        Task<IEnumerable<SearchDTO>> SearchTrack(string name, int offset);

        Task<IEnumerable<SearchDTO>> SearchV2(SearchRequestv2 request);
    }
}
