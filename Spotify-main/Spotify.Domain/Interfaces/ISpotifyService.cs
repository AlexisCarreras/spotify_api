using Spotify.Domain.Abstract;
using Spotify.Domain.Models.Album;
using Spotify.Domain.Models.Artist;
using Spotify.Domain.Models.Track;

namespace Spotify.Domain.Interfaces
{
    public interface ISpotifyService
    {
        Search Search(string name, string type);
        ArtistModel Artist(string id);
        AlbumArtist AlbumsArtist(string id);
        AlbumModel Album(string id);
        AlbumTracksModel AlbumTracks(string id);
        TrackModel Track(string id);
        TrackFeaturesModel TrackFeatures(string id);
        ArtistTopTracks TopTracks(string id, string market = "from_token");
    }
}
