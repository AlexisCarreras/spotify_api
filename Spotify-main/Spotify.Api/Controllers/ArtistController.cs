using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/artist/{id}")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistBusiness _artistBusiness;
        public ArtistController()
        {
            _artistBusiness = new ArtistBusiness();
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var response = _artistBusiness.artist(id);
            return Ok(response);
        }
    }
}