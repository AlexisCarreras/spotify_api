using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using System.Collections.Generic;

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
            

            List<Album> lst = new List<Album>();

            foreach (Album a in response)
            {
                Album _album = new Album()
                {
                    albumArtist = a.albumArtist,
                    id = a.id,
                    images = a.images,
                    name = a.name,
                    totalTracks = a.totalTracks,
                    type = a.type

                };

                lst.Add(_album);

            }

            return Ok(lst);


        }
    }
}
