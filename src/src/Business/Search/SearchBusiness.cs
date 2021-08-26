using System.Collections.Generic;
using System.Threading.Tasks;
using Featurify.Business.Mapper;
using Featurify.Business.Search.Strategy;
using Featurify.Core.Enums;
using Featurify.Core.Interfaces;
using Featurify.Core.Models.Search;
using Featurify.Core.Request;
using Featurify.Core.Response;

namespace Featurify.Business.Search
{
    public class SearchBusiness : ISearchBusiness
    {
        private readonly ISpotifyService _searchService;
        private SearchStrategy.IStrategy _builderStrategy;
        public SearchBusiness(ISpotifyService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<SearchDTO>> SearchArtist(string name, int offset)
        {
            var responseService = (await Task.FromResult(_searchService.Search(name, SearchEnum.Artist, offset)));
            var items = ((ArtistSearch)responseService.Result).artists.items;
            List <SearchDTO> listArtista = new List<SearchDTO>();

            for (int i = 0; i < items.Length; i++)
            {
                SearchDTO artist = new SearchDTO()
                {
                    id = items[i].id,
                    imagen_url = items[i].images.Length == 0 ? "" : items[i].images[0].url,
                    name_artist = items[i].name,
                    type = items[i].type,
                };
                listArtista.Add(artist);
            }
            return listArtista;
        }

        public async Task<IEnumerable<SearchDTO>> SearchAlbum(string name, int offset)
        {
            var responseService = (await Task.FromResult(_searchService.Search(name, SearchEnum.Album, offset)));
            var items = ((AlbumSearch)responseService.Result).albums.items;
            List <SearchDTO> listAlbum = new List<SearchDTO>();

            for (int i = 0; i < items.Length; i++)
            {
                SearchDTO album = new SearchDTO()
                {
                    id = items[i].id,
                    imagen_url = items[i].images.Length == 0 ? "" : items[i].images[0].url,
                    name_artist = items[i].artists[0].name,
                    name_album = items[i].name,
                    type = items[i].type,
                };
                listAlbum.Add(album);
            }
            return listAlbum;
        }

        public async Task<IEnumerable<SearchDTO>> SearchTrack(string name, int offset)
        {
            var responseService = (await Task.FromResult(_searchService.Search(name, SearchEnum.Track, offset)));
            var items = ((TrackSearch)responseService.Result).tracks.items;
            List <SearchDTO> listTrack = new List<SearchDTO>();

            for (int i = 0; i < items.Length; i++)
            {
                SearchDTO track = new SearchDTO()
                {
                    id = items[i].id,
                    imagen_url = items[i].album.images.Length == 0 ? "" : items[i].album.images[0].url,
                    name_artist = items[i].artists[0].name,
                    name_track = items[i].name,
                    track_lenght = TrackLenghtFormater.LenghtFormater(items[i].duration_ms),
                    favorite = false,
                    type = items[i].type,
                };
                listTrack.Add(track);
            }
            return listTrack;
        }

        // Contexto
        public async Task<IEnumerable<SearchDTO>> SearchV2(SearchRequestv2 request)
        {
            // llamar a servicio
            var responseService = await Task.FromResult(_searchService.Search(request.Name, request.SearchType, request.OffSet));

            // switch emum

            _builderStrategy = request.SearchType switch
            {
                SearchEnum.Artist => new SearchStrategy.Artist(),
                SearchEnum.Album => new SearchStrategy.Album(),
                SearchEnum.Track => new SearchStrategy.Track(),
                _ => throw new System.NotImplementedException(),
            };

            // ejecutar metodo, build response
            var response = _builderStrategy.BuildResponse(responseService.Result);

            // return
            return response;
        }
    }
}