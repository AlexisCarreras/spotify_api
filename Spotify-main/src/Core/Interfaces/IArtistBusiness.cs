using Spotify.Core.Response;

namespace Spotify.Core.Interfaces
{
    public interface IArtistBusiness
    {
        Artist artist(string id);
    }
}
