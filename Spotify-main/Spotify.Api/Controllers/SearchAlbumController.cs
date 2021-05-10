using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/search/album")]
    [ApiController]
    public class SearchAlbumController : ControllerBase
    {
        private readonly SearchBusiness _searchBusiness;
        public SearchAlbumController()
        {
            _searchBusiness = new SearchBusiness();
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type = SearchEnum.Album)
        {
            var response = _searchBusiness.SearchAlbum(name, type);

            return Ok(response);




        }
    }
}
