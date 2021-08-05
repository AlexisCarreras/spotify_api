using Spotify.Core.Abstract;
using Spotify.Core.Models.Album;
using Spotify.Core.Models.Artist;
using Spotify.Core.Models.Track;

namespace Spotify.Core.Interfaces
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
