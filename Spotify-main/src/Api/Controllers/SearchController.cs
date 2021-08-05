using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Enums;
using Spotify.Core.Interfaces;

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
        public IActionResult GetArtist(string name, SearchEnum type = SearchEnum.Artist)
        {
            var response = _searchBusiness.SearchArtist(name, type);
            return Ok(response);
        }

        [HttpGet("track")]
        public IActionResult GetTrack(string name, SearchEnum type = SearchEnum.Track)
        {
            var response = _searchBusiness.SearchTrack(name, type);
            return Ok(response);
        }

        [HttpGet("album")]
        public IActionResult GetAlbum(string name, SearchEnum type = SearchEnum.Album)
        {
            var response = _searchBusiness.SearchAlbum(name, type);
            return Ok(response);
        }
    }
}