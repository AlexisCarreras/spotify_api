using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;

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
        public IActionResult GetArtist(string id)
        {
            var response = _artistBusiness.artist(id);
            return Ok(response);
        }

        [HttpGet("{id}/albums")]
        public IActionResult GetAlbumsArtist(string id, int offset)
        {
            var response = _artistBusiness.ArtistAlbums(id, offset);
            return Ok(response);
        }
    }
}