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
			TrackFeaturesModel trackFeatures = _trackService.TrackFeatures(id);
			return _mapper.Map<Track>(responseService);
			
			//Track track = new Track()
			//{
			//	id = responseService.id,
			//	name = responseService.name,
			//	artistName = string.Join(", ", responseService.artists.Select(a => a.name)),
			//	image = responseService.album.images.Length == 0 ? "" : responseService.album.images[0].url,
			//	albumName = responseService.album.name,
			//	trackLength = TrackLenghtFormater.LenghtFormater(responseService.duration_ms),
			//	type = responseService.type,
			//	previewUrl = responseService.preview_url,
			//	favorite = false,
			//};
   //         track.TrackMapping(trackFeatures);
   //         return track;
		}
	}
}