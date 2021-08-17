using System.Linq;
using Spotify.Business.Mapper;
using Spotify.Core.Interfaces;
using Spotify.Core.Models.Track;
using Spotify.Core.Response;

namespace Spotify.Business
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
			TrackModel responseService = _trackService.Track(id);
			TrackFeaturesModel trackFeatures = _trackService.TrackFeatures(id);
			
			Track track = new Track()
			{
				id = responseService.id,
				name = responseService.name,
				albumName = responseService.album.name,
				trackLength = TrackLenghtFormater.LenghtFormater(responseService.duration_ms),
				type = responseService.type,
				previewUrl = responseService.preview_url,
				favorite = false,
			};
			track.artistName = string.Join(", ", responseService.artists.Select(a => a.name));
			track.image = responseService.album.images.Length == 0 ? "" : responseService.album.images[0].url;
			
            track.TrackMapping(trackFeatures);

            return track;
		}
	}
}