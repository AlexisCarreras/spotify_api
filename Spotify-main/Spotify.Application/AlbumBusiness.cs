using Spotify.Domain.Models;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using static Spotify.Domain.Models.AlbumArtist;

namespace Spotify.Application
{
    public class AlbumBusiness
    {
        private Service.SpotifyService _albumService { get; set; }
        public AlbumBusiness()
        {
            _albumService = new Service.SpotifyService();
        }

        public Service.SpotifyService GetAlbumService()
        {
            return _albumService;
        }

        public Album Album(string id)
        {
            var responseService = _albumService.Album(id);

            Album album = new Album()
            {
                albumArtist = responseService.artists[0].name,
                id = responseService.id,
                images = responseService.images,
                name = responseService.name,
                totalTracks = responseService.total_tracks,
                type = responseService.type,
                tracks = AlbumTracks(id).ToArray()
            };
            return album;
        }

        
        public List<Track> AlbumTracks(string id)
        {
            var responseService = _albumService.AlbumTracks(id);
            var arrTracks = responseService.items;

            List<Track> albumTracks = new List<Track>();
            for (int i = 0; i < arrTracks.Length; i++)
            {
                var namealb = new TrackBusiness(); 

                Track track = new Track()
                {
                    albumName = namealb.Track(arrTracks[i].id).albumName, //Lo obtengo de la API de tracks
                    artistName = arrTracks[i].artists[0].name,
                    id = arrTracks[i].id,
                    name = arrTracks[i].name,
                    trackLength = arrTracks[i].duration_ms,
                    previewUrl = arrTracks[i].preview_url,
                    favorite = false
                };
                albumTracks.Add(track);
            }
            return albumTracks;
        }
    }
}
