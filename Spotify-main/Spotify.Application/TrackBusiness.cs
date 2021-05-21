using Spotify.Application.Mapper;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Spotify.Domain.Interfaces;

namespace Spotify.Application
{
	public class TrackBusiness : ITrackBusiness
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

			var trackFeatures = _trackService.TrackFeatures(id);

			Track track = new Track()
			{
				albumName = responseService.album.name,
				id = responseService.id,
				artistName = responseService.artists[0].name,
				name = responseService.name,
				trackLength = responseService.duration_ms,
				previewUrl = responseService.preview_url,
				favorite = false,
			};
			track.TrackMapping(trackFeatures);
			return track;
		}
	}
}