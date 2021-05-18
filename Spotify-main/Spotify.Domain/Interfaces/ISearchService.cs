using Spotify.Domain.Models;
using Spotify.Domain.Models.Search;

namespace Spotify.Domain.Interfaces
{
    public interface ISearchService
    {
        ArtistSearch Search(string name, string type);
    }
}
