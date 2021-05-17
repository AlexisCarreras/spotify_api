using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly TrackBusiness _trackBusiness;
        public TrackController()
        {
            _trackBusiness = new TrackBusiness();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _trackBusiness.Track(id);
            return Ok(response);
        }
    }
}