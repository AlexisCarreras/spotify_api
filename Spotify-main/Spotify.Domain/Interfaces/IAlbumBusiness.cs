using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Interfaces
{
    public interface IAlbumBusiness
    {
        Album Album(string id);


    }
}
