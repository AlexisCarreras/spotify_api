using Spotify.Domain.Models;
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
                topTracks = TopTracks(id).ToArray()
            };

            return artist;
        }

        public List<Track> TopTracks(string id, string market = "from_token")
        {
            var responseService = _artistService.TopTracks(id, market);
            var arrTracks = ((ArtistTopTracks)responseService).tracks;


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

        public Album albumArtist(string id)
        {
            var responseService = _artistService.AlbumsArtist(id);

            Album album = new Album()
            {
                name = responseService.name,
                albumArtist = responseService.artists[0].name,
                id = responseService.id,
                //images = responseService.images,
                totalTracks = responseService.total_tracks,
                type = responseService.type,
            };

            return album;
        }

	}
}
