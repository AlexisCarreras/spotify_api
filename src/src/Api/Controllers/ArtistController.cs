﻿using Featurify.Core.Interfaces;
using Featurify.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Featurify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistBusiness _artistBusiness;
        public ArtistController(IArtistBusiness artistBusiness)
        {
            _artistBusiness = artistBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(string id)
        {
            var response = await _artistBusiness.artist(id);
            return Ok(response);
        }

        [HttpGet("{id}/albums")]
        public async Task<ActionResult<ArtistAlbum>> GetAlbumsArtist(string id, int offset)
        {
            var response = await _artistBusiness.ArtistAlbums(id, offset);
            return Ok(response);
        }

        [HttpGet("{id}/top-tracks")]
        public async Task<ActionResult<ArtistTrack>> GetArtistTopTracks(string id, string market = "AR")
        {
            var response = await _artistBusiness.ArtistTopTracks(id, market);
            return Ok(response);
        }
    }
}