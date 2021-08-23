using System.Linq;
using AutoMapper;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Track;
using Spotify.Core.Response;

namespace Spotify.Business
{
    public class TrackBusiness : ITrackBusiness
	{
		private ISpotifyService _trackService { get; set; }
		private IMapper _mapper { get; set; }

		public TrackBusiness(ISpotifyService trackService, IMapper mapper)
		{
			_trackService = trackService;
			_mapper = mapper;
		}

		public Track Track(string id)
		{
			TrackModel responseService = _trackService.Track(id);
			return _mapper.Map<Track>(responseService);
		}
		public TrackFeature TrackFeature(string id)
		{
			TrackFeaturesModel responseService = _trackService.TrackFeatures(id);
			return _mapper.Map<TrackFeature>(responseService);
		}
	}
}