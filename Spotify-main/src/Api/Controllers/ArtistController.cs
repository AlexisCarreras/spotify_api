using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;
using Spotify.Core.Response;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBusiness _artistBusiness;
        public ArtistController(IArtistBusiness artistBusiness)
        {
            _artistBusiness = artistBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            var response = await _artistBusiness.artist(id);
            return Ok(response);
        }

        [HttpGet("{id}/albums")]
        public IActionResult GetAlbumsArtist(string id, int offset)
        {
            var response = _artistBusiness.ArtistAlbums(id, offset);
            return Ok(response);
        }

        [HttpGet("{id}/top-tracks")]
        public IActionResult GetArtistTopTracks(string id, string market = "AR")
        {
            var response = _artistBusiness.ArtistTopTracks(id, market);
            return Ok(response);
        }
    }
}