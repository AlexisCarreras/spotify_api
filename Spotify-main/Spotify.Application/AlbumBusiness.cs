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
        private Service.SpotifyService _artistService { get; set; }
        public AlbumBusiness()
        {
            _artistService = new Service.SpotifyService();
        }

        public Service.SpotifyService GetArtistService()
        {
            return _artistService;
        }

        public Album artist(string id)
        {
            Album artist = new Album();
;           return artist;
        }
    }
}
