﻿using System;
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

        public List<SearchDTO> SearchArtist(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());
            var arrItem = ((ArtistSearch)responseService).artists.items;
            List<SearchDTO> listArtista = new List<SearchDTO>();

            for (int i = 0; i < arrItem.Length; i++)
            {
                SearchDTO artist = new SearchDTO()
                {
                    id = arrItem[i].id,
                    imagen_url = arrItem[i].images[0].url,
                    name_artist = arrItem[i].name,
                    type = arrItem[i].type,
                };
                listArtista.Add(artist);
            }
            return listArtista;
        }

        public List<SearchDTO> SearchAlbum(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());
            var arrItem = ((AlbumSearch)responseService).albums.items;
            List<SearchDTO> listAlbum = new List<SearchDTO>();

            for (int i = 0; i < arrItem.Length; i++)
            {
                SearchDTO album = new SearchDTO()
                {
                    id = arrItem[i].id,
                    imagen_url = arrItem[i].images[0].url,
                    name_artist = arrItem[i].artists[0].name,
                    name_album = arrItem[i].name,
                    type = arrItem[i].type,
                };
                listAlbum.Add(album);
            }
            return listAlbum;
        }

        public List<SearchDTO> SearchTrack(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());
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
                listTrack.Add(track);
            }
            return listTrack;
        }
    }
}