using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Featurify.Core.Entities;
using Featurify.Core.Response.Favorite;
using Featurify.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PruebaFeaturify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FTrackController : ControllerBase
    {
        private readonly FeaturifyContext _context;

        public FTrackController(FeaturifyContext context)
        {
            _context = context;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackEntity>>> GetTracks()
        {
            //Claim claim = User.Claims.FirstOrDefault(c => c.Type.Equals("user_id"));

            //System.Console.WriteLine($"mi id es: {claim.Value}");

            return await _context.Tracks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackEntity>> GetTracks(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<TrackEntity>> PostTracks(FTrackDTO track)
        {
            if (_context.Tracks.Any(a => a.TrackIdSpotify == track.TrackIdSpotify))
            {
                return Ok("El Track ya está registado en la BBDD");
            }
            else
            {
                TrackEntity t = new TrackEntity()
                {
                    AlbumIdSpotify = track.AlbumIdSpotify,
                    TrackIdSpotify = track.TrackIdSpotify,
                    ArtistIdSpotify = track.ArtistIdSpotify,
                    TrackName = track.TrackName
                };

                _context.Tracks.Add(t);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTracks", new { id = t.Id }, t);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTracks(int id)
        {
            var tracks = await _context.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(tracks);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
