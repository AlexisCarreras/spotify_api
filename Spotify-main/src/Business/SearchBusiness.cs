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
            var responseService = _searchService.Search(name, type.ToString(), offset);
            var arrItem = ((ArtistSearch)responseService).artists.items;
            List<SearchDTO> listArtista = new List<SearchDTO>();

            for (int i = 0; i < arrItem.Length; i++)
            {
                SearchDTO artist = new SearchDTO()
                {
                    id = arrItem[i].id,
                    //imagen_url = arrItem[i].images[0].url,
                    name_artist = arrItem[i].name,
                    type = arrItem[i].type,
                };
                artist.imagen_url = arrItem[i].images.Length == 0 ? "" : arrItem[i].images[0].url;
				listArtista.Add(artist);
            }
            return listArtista;
        }

        public List<SearchDTO> SearchAlbum(string name, SearchEnum type, int offset)
        {
            var responseService = _searchService.Search(name, type.ToString(), offset);
            var arrItem = ((AlbumSearch)responseService).albums.items;
            List<SearchDTO> listAlbum = new List<SearchDTO>();

            for (int i = 0; i < arrItem.Length; i++)
            {
                SearchDTO album = new SearchDTO()
                {
                    id = arrItem[i].id,
                    //imagen_url = arrItem[i].images[0].url,
                    name_artist = arrItem[i].artists[0].name,
                    name_album = arrItem[i].name,
                    type = arrItem[i].type,
                };
                album.imagen_url = arrItem[i].images.Length == 0 ? "" : arrItem[i].images[0].url;
                listAlbum.Add(album);
            }
            return listAlbum;
        }
        //Alexis
        public List<SearchDTO> SearchTrack(string name, SearchEnum type, int offset)
        {
            var responseService = _searchService.Search(name, type.ToString(), offset);
            var arrItem = ((TrackSearch)responseService).tracks.items;
            List<SearchDTO> listTrack = new List<SearchDTO>();

            for (int i = 0; i < arrItem.Length; i++)
            {
                SearchDTO track = new SearchDTO()
                {
                    id = arrItem[i].id,
                    imagen_url = arrItem[i].album.images[0].url,
                    name_artist = arrItem[i].artists[0].name,
                    name_track = arrItem[i].name,
                    track_lenght = TrackLenghtFormater.LenghtFormater(arrItem[i].duration_ms),
                    favorite = false,
                    type = arrItem[i].type,
                };
                track.imagen_url = arrItem[i].album.images.Length == 0 ? "" : arrItem[i].album.images[0].url;
                listTrack.Add(track);
            }
            return listTrack;
        }
    }
}