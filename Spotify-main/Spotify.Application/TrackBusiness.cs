using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Application
{
	public class TrackBusiness
	{
        private Service.SpotifyService _trackService { get; set; }
        public TrackBusiness()
        {
            _trackService = new Service.SpotifyService();
        }

        public Service.SpotifyService GetTrackService()
        {
            return _trackService;
        }

        public Track Track(string id)
        {
            var responseService = _trackService.Track(id);

            Track track = new Track()
            {
                albumName = responseService.album.name,
                id = responseService.id,
                artistName = responseService.artists[0].name,
                name = responseService.name,
                trackLength = responseService.duration_ms,
                previewUrl = responseService.preview_url,
                favorite = false
            };
            return track;
        }
    }
}