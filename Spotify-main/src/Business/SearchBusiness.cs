using System;
using System.Collections.Generic;
using Spotify.Business.Mapper;
using Spotify.Core.Enums;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Search;
using Spotify.Core.Response;

namespace Spotify.Business
{
    public class SearchBusiness : ISearchBusiness
    {
        private ISpotifyService _searchService { get; set; }
        public SearchBusiness(ISpotifyService searchService)
        {
            _searchService = searchService;
        }

        public List<SearchDTO> SearchArtist(string name, SearchEnum type, int offset)
        {
            var responseService = ((ArtistSearch)_searchService.Search(name, type.ToString(), offset)).artists.items;
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

        public List<SearchDTO> SearchAlbum(string name, SearchEnum type, int offset)
        {
            var responseService = ((AlbumSearch)_searchService.Search(name, type.ToString(), offset)).albums.items;
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

        public List<SearchDTO> SearchTrack(string name, SearchEnum type, int offset)
        {
            var responseService = ((TrackSearch)_searchService.Search(name, type.ToString(), offset)).tracks.items;
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
    }
}