using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;

namespace Spotify.Domain.Interfaces
{
    public interface ISearchBusiness
    {
        List<Artist> Search(string name, SearchEnum type);
    }
}
