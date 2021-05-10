using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/search/track")]
    [ApiController]
    public class SearchTrackController : ControllerBase
    {
        private readonly SearchBusiness _searchBusiness;
        public SearchTrackController()
        {
            _searchBusiness = new SearchBusiness();
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type = SearchEnum.Track)
        {
            var response = _searchBusiness.SearchTrack(name, type);

            return Ok(response);




        }
    }
}
