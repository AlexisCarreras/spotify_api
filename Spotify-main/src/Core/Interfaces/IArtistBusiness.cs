﻿using Spotify.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Core.Interfaces
{
    public interface IArtistBusiness
    {
        Task<Artist> artist(string id);
        List<ArtistAlbum> ArtistAlbums(string id, int offset);
        List<ArtistTrack> ArtistTopTracks(string id, string market);
    }
}
