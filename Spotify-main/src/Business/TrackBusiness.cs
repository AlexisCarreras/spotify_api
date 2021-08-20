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
		//	TrackFeature TF = new TrackFeature()
		//	{
		//		acousticness = (int)(responseService.acousticness*1000),
		//		danceability = (int)(responseService.danceability*1000),
		//		energy = (int)(responseService.energy*1000),
		//		instrumentalness = (int)(responseService.instrumentalness*1000),
		//		key = responseService.key.ToString(),
		//		liveness = (int)(responseService.liveness*1000),
		//		mode = responseService.mode.ToString(),
		//		speechiness = (int)(responseService.speechiness*1000),
		//		tempo = responseService.tempo,
		//		valence = (int)(responseService.valence*1000),
		//};
			

		//	return TF;
		}
	}
}