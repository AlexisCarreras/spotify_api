using Spotify.Domain.Models;

namespace Spotify.Domain.Interfaces
{
    public interface ISearchService
    {
        ArtistSearch Search(string name, string type);
    }
}
