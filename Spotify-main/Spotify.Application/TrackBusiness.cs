using Spotify.Application.Mapper;
using Spotify.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Mapper;

namespace Spotify.Application
{
	public class TrackBusiness : ITrackBusiness
	{
		private ISpotifyService _trackService { get; set; }
		public TrackBusiness(ISpotifyService trackService)
		{
			_trackService = trackService;
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
				images = ImageMapper.ImageMapping(responseService.album.images),
				type = responseService.type,
				previewUrl = responseService.preview_url,
				favorite = false,
			};
			track.TrackMapping(trackFeatures);
			return track;
		}
	}
}