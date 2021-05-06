using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Enums;

namespace Spotify.Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchBusiness _searchBusiness;
        public SearchController()
        {
            _searchBusiness = new SearchBusiness();
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type)
        {
            var response = _searchBusiness.Search(name, type);
            return Ok(response);
        }
    }
}
