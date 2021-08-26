using Featurify.Core.Abstract;
using Featurify.Core.Enums;
using Featurify.Core.Models.Album;
using Featurify.Core.Models.Artist;
using Featurify.Core.Models.Track;
using System.Threading.Tasks;

namespace Featurify.Core.Interfaces
{
    public interface ISpotifyService
    {
        Task<Search> Search(string name, SearchEnum type, int offset);
        Task<ArtistModel> Artist(string id);
        Task<AlbumArtist> AlbumsArtist(string id, int offset);
        Task<ArtistTopTracks> TopTracks(string id, string market);
        Task<AlbumModel> Album(string id);
        Task<AlbumTracksModel> AlbumTracks(string id);
        Task<TrackModel> Track(string id);
        Task<TrackFeaturesModel> TrackFeatures(string id);

    }
}
