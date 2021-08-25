﻿using Spotify.Core.Abstract;
using Spotify.Core.Enums;
using Spotify.Core.Models.Album;
using Spotify.Core.Models.Artist;
using Spotify.Core.Models.Track;
using System.Threading.Tasks;

namespace Spotify.Core.Interfaces
{
    public interface ISpotifyService
    {
        Search Search(string name, SearchEnum type, int offset);
        ArtistModel Artist(string id);
        AlbumArtist AlbumsArtist(string id);
        AlbumArtist AlbumsArtist(string id, int offset);
        AlbumModel Album(string id);
        AlbumTracksModel AlbumTracks(string id);
        Task<TrackModel> Track(string id);
        Task<TrackFeaturesModel> TrackFeatures(string id);
        ArtistTopTracks TopTracks(string id, string market);
    }
}
