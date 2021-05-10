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
    public class SearchArtistController : ControllerBase
    {
        private readonly SearchBusiness _searchBusiness;
        public SearchArtistController()
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