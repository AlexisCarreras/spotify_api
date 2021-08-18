using Spotify.Core.Abstract;
using Spotify.Core.Models.Album;
using Spotify.Core.Models.Artist;
using Spotify.Core.Models.Track;

namespace Spotify.Core.Interfaces
{
    public interface ISpotifyService
    {
        Search Search(string name, string type, int offset);
        ArtistModel Artist(string id);
        AlbumArtist AlbumsArtist(string id, int offset);
        AlbumModel Album(string id);
        AlbumTracksModel AlbumTracks(string id);
        TrackModel Track(string id);
        TrackFeaturesModel TrackFeatures(string id);
        ArtistTopTracks TopTracks(string id, string market = "from_token");
    }
}
