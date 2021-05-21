using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBusiness _artistBusiness;
        public ArtistController()
        {
            _artistBusiness = new ArtistBusiness();
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(string id)
        {
            var response = _artistBusiness.artist(id);
            return Ok(response);
        }

		//[HttpGet("{id}/toptracks")]
		//public IActionResult GetTopTracks(string id)
		//{
		//	var response = _artistBusiness.TopTracks(id);
		//	return Ok(response);
		//}

		//[HttpGet("{id}/albums")]
		//public IActionResult GetAlbumsArtist(string id)
		//{
		//	var response = _artistBusiness.AlbumArtist(id);
		//	return Ok(response);
		//}
	}
}