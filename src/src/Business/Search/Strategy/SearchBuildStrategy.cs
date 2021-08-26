using System.Collections.Generic;
using System.Linq;
using Featurify.Business.Mapper;
using Featurify.Core.Models.Search;
using Featurify.Core.Response;

namespace Featurify.Business.Search.Strategy
{
    public abstract class SearchStrategy
    {
        public interface IStrategy
        {
            IEnumerable<SearchDTO> BuildResponse(Core.Abstract.Search responseService);
        }
        public class Artist : IStrategy
        {
            public IEnumerable<SearchDTO> BuildResponse(Core.Abstract.Search responseService)
            {
                var current = responseService as ArtistSearch;

                var items = current.artists.items;

                return items.Select(artist => new SearchDTO
                {
                    id = artist.id,
                    imagen_url = artist.images.Length == 0 ? "" : artist.images[0].url,
                    name_artist = artist.name,
                    type = artist.type
                });
            }
        }
        public class Album : IStrategy
        {
            public IEnumerable<SearchDTO> BuildResponse(Core.Abstract.Search responseService)
            {
                var current = responseService as AlbumSearch;
                var items = current.albums.items;

                return items.Select(album => new SearchDTO
                {
                    id = album.id,
                    imagen_url = album.images.Length == 0 ? "" : album.images[0].url,
                    name_artist = album.artists[0].name,
                    name_album = album.name,
                    type = album.type
                });
            }
        }
        public class Track : IStrategy
        {
            public IEnumerable<SearchDTO> BuildResponse(Core.Abstract.Search responseService)
            {
                var current = responseService as TrackSearch;
                var items = current.tracks.items;

                return items.Select(track => new SearchDTO
                {
                    id = track.id,
                    imagen_url = track.album.images.Length == 0 ? "" : track.album.images[0].url,
                    name_artist = track.artists[0].name,
                    name_track = track.name,
                    track_lenght = TrackLenghtFormater.LenghtFormater(track.duration_ms),
                    favorite = false,
                    type = track.type,
                });
            }
        }
    }
}
