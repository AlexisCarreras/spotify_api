using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Featurify.Core.Entities;
using Featurify.Core.Response.Favorite;
using Featurify.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace PruebaFeaturify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesTracksController : ControllerBase
    {
        private readonly FeaturifyContext _context;

        public FavoritesTracksController(FeaturifyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<UserTrackEntity>>> GetFavoritesTracks()
        {
            Claim claim = User.Claims.FirstOrDefault(c => c.Type.Equals("user_id"));

            return await _context.UsersTracks.Where(a => a.UserId == claim.Value).ToListAsync();
        }

        [HttpPost("favorite")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostFavorite([FromBody]FTrackDTO track)
        {
            Claim claim = User.Claims.FirstOrDefault(c => c.Type.Equals("user_id"));
            if (ExisteEnTablaTracks(track))
            {
                if (ExisteEnTablaUsersTracks(track))
                {
                    var x = _context.UsersTracks.FirstOrDefault(a => a.TrackId == getIdFromTablaTracks(track));
                    x.Enable = !x.Enable;
                    _context.UsersTracks.Update(x);

                    await _context.SaveChangesAsync();

                    return CreatedAtAction("FavTrackSetEnable", x);
                }
                else
                {
                    UserTrackEntity UsTr = new UserTrackEntity()
                    {
                        UserId = claim.Value,
                        TrackId = _context.Tracks.Find(getIdFromTablaTracks(track)).Id,
                        Enable = true,
                    };
                    _context.UsersTracks.Add(UsTr);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetUsersTracks", new { id = UsTr.Id }, UsTr);
                }
            }
            else
            {
                TrackEntity t = new TrackEntity()
                {
                    AlbumIdSpotify = track.AlbumIdSpotify,
                    TrackIdSpotify = track.TrackIdSpotify,
                    ArtistIdSpotify = track.ArtistIdSpotify,
                    TrackName = track.TrackName,
                };
                _context.Tracks.Add(t);
                await _context.SaveChangesAsync();

                UserTrackEntity UsTr = new UserTrackEntity()
                {
                    UserId = claim.Value,
                    TrackId = _context.Tracks.Find(getIdFromTablaTracks(track)).Id,
                    Enable = true,
                };
                _context.UsersTracks.Add(UsTr);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsersTracks", new { id = UsTr.Id }, UsTr);
            }
        }

        private bool ExisteEnTablaTracks(FTrackDTO track)
        {
            return _context.Tracks.Any(a => a.TrackIdSpotify == track.TrackIdSpotify);
        }

        private bool ExisteEnTablaUsersTracks(FTrackDTO track)
        {
            return _context.UsersTracks.Any(a => a.TrackId == getIdFromTablaTracks(track));
        }

        private int getIdFromTablaTracks(FTrackDTO track)
        {
            var x =  _context.Tracks.Where(a => a.TrackIdSpotify == track.TrackIdSpotify).Select(a => a.Id);
            var idtrack = 0;
            foreach(var a in x)
            {
                idtrack = a;
            }
            return idtrack;

        }
    }
}
