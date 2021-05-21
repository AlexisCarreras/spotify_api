using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchBusiness _searchBusiness;
        public SearchController()
        {
            _searchBusiness = new SearchBusiness();
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