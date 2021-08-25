using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;
using Spotify.Core.Response;
using System.Threading.Tasks;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackBusiness _trackBusiness;

		public TrackController(ITrackBusiness trackBusiness)
		{
			_trackBusiness = trackBusiness;
		}

		[HttpGet("{id}")]
        public async Task<ActionResult<Track>> Get(string id)
        {
            var response = await _trackBusiness.Track(id);
            return response;
        }

        [HttpGet("{id}/track-features")]
        public async Task<ActionResult<TrackFeature>> GetFeatures(string id)
        {
            var response = await _trackBusiness.TrackFeature(id);
            return Ok(response);
        }
    }
}