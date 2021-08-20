using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;

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
        public IActionResult Get(string id)
        {
            var response = _trackBusiness.Track(id);
            return Ok(response);
        }

        [HttpGet("{id}/track-features")]
        public IActionResult GetFeatures(string id)
        {
            var response = _trackBusiness.TrackFeature(id);
            return Ok(response);
        }
    }
}