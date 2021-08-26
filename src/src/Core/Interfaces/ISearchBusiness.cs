using System.Collections.Generic;
using System.Threading.Tasks;
using Featurify.Core.Request;
using Featurify.Core.Response;

namespace Featurify.Core.Interfaces
{
    public interface ISearchBusiness
    {
        Task<IEnumerable<SearchDTO>> SearchArtist(string name, int offset);
        Task<IEnumerable<SearchDTO>> SearchAlbum(string name, int offset);
        Task<IEnumerable<SearchDTO>> SearchTrack(string name, int offset);

        Task<IEnumerable<SearchDTO>> SearchV2(SearchRequestv2 request);
    }
}
