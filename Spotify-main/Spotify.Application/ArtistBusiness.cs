using Spotify.Domain.Models;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

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
                images = responseService.images
            };

            return artist;
        }

    }
}
