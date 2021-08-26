//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Featurify.Core.Entities;
//using Featurify.Core.Response.Favorite;
//using Featurify.Infrastructure.Data;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PruebaFeaturify.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FavoritesTracksController : ControllerBase
//    {
//        private readonly FeaturifyContext _context;

//        public FavoritesTracksController(FeaturifyContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<FavoritesTrackEntity>>> GetFavoritesTracks()
//        {
//            return await _context.FavoritesTracks.ToListAsync();
//        }

//        [HttpPost]
//        public async Task<ActionResult<FavoritesTrackEntity>> PostFavoritesTracks(FavoriteTrackDTO favoriteTrack)
//        {
//            FavoritesTrackEntity ft = new FavoritesTrackEntity()
//            {
//                TrackId = favoriteTrack.TrackId,
//                UsuarioId = favoriteTrack.UsuarioId
//            };

//            _context.FavoritesTracks.Add(ft);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (FavoritesTracksExists(ft.Id))
//                {
//                    return Conflict($"El track {ft.Id} ya existe en la base de datos");
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetFavoritesTracks", new { id = ft.Id }, ft);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteFavoritesTracks(string id)
//        {
//            var favoritesTracks = await _context.FavoritesTracks.FindAsync(id);
//            if (favoritesTracks == null)
//            {
//                return NotFound();
//            }

//            _context.FavoritesTracks.Remove(favoritesTracks);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool FavoritesTracksExists(int id)
//        {
//            return _context.FavoritesTracks.Any(e => e.Id == id);
//        }
//    }
//}
