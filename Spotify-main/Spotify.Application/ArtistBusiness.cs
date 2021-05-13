﻿using Spotify.Domain.Models;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using static Spotify.Domain.Models.AlbumArtist;

namespace Spotify.Application
{
	public class ArtistBusiness
	{
        private Service.SpotifyService _artistService { get; set; }
        public ArtistBusiness()
        {
            _artistService = new Service.SpotifyService();
        }

        public Service.SpotifyService GetArtistService()
        {
            return _artistService;
        }

        public Artist artist(string id)
        {
            var responseService = _artistService.Artist(id);

            Artist artist = new Artist()
            {
                name = responseService.name,
                id = responseService.id,
                type = responseService.type,
                genres = responseService.genres,
                popularity = responseService.popularity,
                images = responseService.images,
                topTracks = TopTracks(id).ToArray(),
                albums = AlbumArtist(id).ToArray(),
                
            };

            return artist;
        }

        public List<Track> TopTracks(string id, string market = "from_token")
        {
            var responseService = _artistService.TopTracks(id, market);
            var arrTracks = responseService.tracks;


            List<Track> listTopTracks = new List<Track>();
            for(int i = 0; i<arrTracks.Length;i++)
            {
                Track track = new Track()
                {
                    albumName = arrTracks[i].album.name,
                    artistName = arrTracks[i].artists[0].name,
                    id = arrTracks[i].id,
                    name = arrTracks[i].name,
                    trackLength = arrTracks[i].duration_ms,
                    previewUrl = arrTracks[i].preview_url,
                    favorite = false
                };
                listTopTracks.Add(track);
            }
            return listTopTracks;
        }

        public List<Album> AlbumArtist(string id)
        {
            var responseService = _artistService.AlbumsArtist(id);
            var arrAlbums = responseService.items;

            List<Album> listAlbums = new List<Album>();
            for (int i = 0; i < arrAlbums.Length; i++)
            {
                Album album = new Album()
                {
                    name = arrAlbums[i].name,
                    albumArtist = arrAlbums[i].artists[0].name,
                    id = arrAlbums[i].id,
                    images = arrAlbums[i].images,
                    totalTracks = arrAlbums[i].total_tracks,
                    type = arrAlbums[i].type
                    
                };
                listAlbums.Add(album);
            }
            return listAlbums;
        }
	}
}
