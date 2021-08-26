using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Core.Data;
using Spotify.Core.Models;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<Tracks>>> GetTracks()
        {
            return await _context.Tracks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tracks>> GetTracks(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Tracks>> PostTracks(Tracks tracks)
        {
            _context.Tracks.Add(tracks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTracks", new { id = tracks.Id }, tracks);
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
