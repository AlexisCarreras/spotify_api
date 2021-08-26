using Microsoft.AspNetCore.Mvc;
using Featurify.Core.Interfaces;
using Featurify.Core.Response;
using System.Threading.Tasks;

namespace Featurify.Api.Controllers
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
        public async Task<ActionResult<Album>> Get(string id)
        {
            var response = await _albumBusiness.Album(id);
            return response;
        }

        [HttpGet("{id}/tracks")]
        public async Task<ActionResult<AlbumTrack>> GetTracks(string id)
        {
            var response = await _albumBusiness.AlbumTracks(id);
            return Ok(response);
        }
    }
}