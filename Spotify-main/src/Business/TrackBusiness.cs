using System.Linq;
using System.Threading.Tasks;
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

		public async Task<Track> Track(string id)
		{
			var responseService = await _trackService.Track(id);
			return _mapper.Map<Track>(responseService);
		}
		public async Task<TrackFeature> TrackFeature(string id)
		{
			TrackFeaturesModel responseService = await _trackService.TrackFeatures(id);
			return _mapper.Map<TrackFeature>(responseService);
		}
	}
}