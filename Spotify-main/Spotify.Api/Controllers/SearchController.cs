using Microsoft.AspNetCore.Mvc;
using Spotify.Application;
using Spotify.Domain.Abstract;
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

            if (response.Count != 0) 
            {
                var tipo = response[0].GetType();
                var listaArtist = new List<Artist>();
                var listaAlbum = new List<Album>();

                if (tipo.Name == "Album")
                {
                    foreach (Album a in response)
                        listaAlbum.Add(a);
                    return Ok(listaAlbum);
                }
                else if (tipo.Name == "Artist")
                {
                    foreach (Artist a in response)
                        listaArtist.Add(a);
                    return Ok(listaArtist);
                }

                return Ok();

            }
            else
            {
                return Ok(new List<Item>());
            }

            

        }
    }
}
