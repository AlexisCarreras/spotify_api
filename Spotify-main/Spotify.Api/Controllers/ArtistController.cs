using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

namespace Spotify.Api.Controllers
{
    [Route("api/artist/")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistBusiness _artistBusiness;
        public ArtistController()
        {
            _artistBusiness = new ArtistBusiness();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _artistBusiness.artist(id);
            return Ok(response);
        }
    }

    //[Route("api/artist/{id}/toptracks")]
    //[ApiController]
    //public class ArtistTopTrackController : ControllerBase
    //{
    //    private readonly ArtistBusiness _artistBusiness;
    //    public ArtistTopTrackController()
    //    {
    //        _artistBusiness = new ArtistBusiness();
    //    }

    //    [HttpGet]
    //    public IActionResult Get(string id)
    //    {
    //        var response = _artistBusiness.TopTracks(id);
    //        return Ok(response);
    //    }
    //}

    //[Route("api/artist/{id}/albums")]
    //[ApiController]
    //public class AlbumsArtistController : ControllerBase
    //{
    //    private readonly ArtistBusiness _artistBusiness;
    //    public AlbumsArtistController()
    //    {
    //        _artistBusiness = new ArtistBusiness();
    //    }

    //    [HttpGet]
    //    public IActionResult Get(string id)
    //    {
    //        var response = _artistBusiness.AlbumArtist(id);
    //        return Ok(response);
    //    }
    //}
}