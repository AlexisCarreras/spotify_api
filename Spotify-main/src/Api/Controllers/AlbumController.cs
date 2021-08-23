using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumBusiness _albumBusiness;

		public AlbumController(IAlbumBusiness albumBusiness)
		{
			_albumBusiness = albumBusiness;
		}

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _albumBusiness.Album(id);
            return Ok(response);
        }

        [HttpGet("{id}/tracks")]
        public IActionResult GetTracks(string id)
        {
            var response = _albumBusiness.AlbumTracks(id);
            return Ok(response);
        }
    }
}