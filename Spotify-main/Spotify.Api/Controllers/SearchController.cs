using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/search/artist")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchBusiness _searchBusiness;
        public SearchController()
        {
            _searchBusiness = new SearchBusiness();
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type = SearchEnum.Artist)
        {
            var response = _searchBusiness.SearchArtist(name, type);

            return Ok(response);
            



        }
    }
}
