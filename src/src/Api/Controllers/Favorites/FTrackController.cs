using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Featurify.Core.Entities;
using Featurify.Core.Response.Favorite;
using Featurify.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaFeaturify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly FeaturifyContext _context;

        public TracksController(FeaturifyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackEntity>>> GetTracks()
        {
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
