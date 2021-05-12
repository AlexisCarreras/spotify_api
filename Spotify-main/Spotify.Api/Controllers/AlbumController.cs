using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/album/{id}")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumBusiness _albumBusiness;
        public AlbumController()
        {
            _albumBusiness = new ArtistBusiness();
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var response = _albumBusiness.artist(id);
            return Ok(response);
        }
    }
}