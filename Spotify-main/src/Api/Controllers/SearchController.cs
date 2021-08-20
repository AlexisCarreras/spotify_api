using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Enums;
using Spotify.Core.Interfaces;
using Spotify.Core.Request;
using Spotify.Core.Response;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchBusiness _searchBusiness;

        public SearchController(ISearchBusiness searchBusiness)
        {
            _searchBusiness = searchBusiness;
        }

        [HttpGet("artist")]
        public IActionResult GetArtist(string name, int offset = 0)
        {
            List<SearchDTO> response = _searchBusiness.SearchArtist(name, offset);
            return Ok(response);
        }

        [HttpGet("track")]
        public IActionResult GetTrack(string name, int offset = 0)
        {
            List<SearchDTO> response = _searchBusiness.SearchTrack(name, offset);
            return Ok(response);
        }

        [HttpGet("album")]
        public IActionResult GetAlbum(string name, int offset = 0)
        {
            List<SearchDTO> response = _searchBusiness.SearchAlbum(name, offset);
            return Ok(response);
        }

        [HttpGet("/api/v2/search")]
        public async Task<IEnumerable<SearchDTO>> GetResource(string name, SearchEnum searchType, int offset)
        {
            var request = new SearchRequestv2(name, searchType, offset);

            var response = await _searchBusiness.SearchV2(request);

            return response;
        }
    }
}