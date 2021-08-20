using System.Collections.Generic;
using System.Threading.Tasks;
using Spotify.Business.Mapper;
using Spotify.Business.Search.Strategy;
using Spotify.Core.Enums;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Search;
using Spotify.Core.Request;
using Spotify.Core.Response;

namespace Spotify.Business.Search
{
    public class SearchBusiness : ISearchBusiness
    {
        private readonly ISpotifyService _searchService;
        private SearchStrategy.IStrategy _builderStrategy;
        public SearchBusiness(ISpotifyService searchService)
        {
            _searchService = searchService;
        }

        public List<SearchDTO> SearchArtist(string name, int offset)
        {
            var responseService = ((ArtistSearch)_searchService.Search(name, SearchEnum.Artist, offset)).artists.items;
            List<SearchDTO> listArtista = new List<SearchDTO>();

            for (int i = 0; i < responseService.Length; i++)
            {
                SearchDTO artist = new SearchDTO()
                {
                    id = responseService[i].id,
                    imagen_url = responseService[i].images.Length == 0 ? "" : responseService[i].images[0].url,
                    name_artist = responseService[i].name,
                    type = responseService[i].type,
                };
                listArtista.Add(artist);
            }
            return listArtista;
        }

        public List<SearchDTO> SearchAlbum(string name, int offset)
        {
            var responseService = ((AlbumSearch)_searchService.Search(name, SearchEnum.Album, offset)).albums.items;
            List<SearchDTO> listAlbum = new List<SearchDTO>();

            for (int i = 0; i < responseService.Length; i++)
            {
                SearchDTO album = new SearchDTO()
                {
                    id = responseService[i].id,
                    imagen_url = responseService[i].images.Length == 0 ? "" : responseService[i].images[0].url,
                    name_artist = responseService[i].artists[0].name,
                    name_album = responseService[i].name,
                    type = responseService[i].type,
                };
                listAlbum.Add(album);
            }
            return listAlbum;
        }

        public List<SearchDTO> SearchTrack(string name, int offset)
        {
            var responseService = ((TrackSearch)_searchService.Search(name, SearchEnum.Track, offset)).tracks.items;
            List<SearchDTO> listTrack = new List<SearchDTO>();

            for (int i = 0; i < responseService.Length; i++)
            {
                SearchDTO track = new SearchDTO()
                {
                    id = responseService[i].id,
                    imagen_url = responseService[i].album.images.Length == 0 ? "" : responseService[i].album.images[0].url,
                    name_artist = responseService[i].artists[0].name,
                    name_track = responseService[i].name,
                    track_lenght = TrackLenghtFormater.LenghtFormater(responseService[i].duration_ms),
                    favorite = false,
                    type = responseService[i].type,
                };
                listTrack.Add(track);
            }
            return listTrack;
        }

        // Contexto
        public async Task<IEnumerable<SearchDTO>> SearchV2(SearchRequestv2 request)
        {
            // llamar a servicio
            Core.Abstract.Search responseService = await Task.FromResult(_searchService.Search(request.Name, request.SearchType, request.OffSet));

            // switch emum

            _builderStrategy = request.SearchType switch
            {
                SearchEnum.Artist => new SearchStrategy.Artist(),
                SearchEnum.Album => new SearchStrategy.Album(),
                SearchEnum.Track => new SearchStrategy.Track(),
                _ => throw new System.NotImplementedException(),
            };

            // ejecutar metodo, build response
            var response = _builderStrategy.BuildResponse(responseService);

            // return
            return response;
        }
    }
}