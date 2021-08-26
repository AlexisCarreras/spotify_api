//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Spotify.Core.Entities;
//using Spotify.Core.Response.Favorite;
//using Spotify.Infrastructure.Data;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Spotify.Api.Controllers
//{
//    [Route("api/[Controller]/")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly FeaturifyContext _context;
//        public UserController(FeaturifyContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public Task<List<UserEntity>> GetUsers()
//        {
//            var response = _context.Users.ToListAsync();
//            return response;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserEntity>> GetUserByID(int id)
//        {
//            var response = await _context.Users.FindAsync(id);
//            return response == null ? NotFound() : response;
//        }

//        [HttpPost]
//        public async Task<ActionResult<UserEntity>> PostUsers(UserDTO users)
//        {
//            UserEntity u = new UserEntity() { Email = users.Email, };

//            _context.Users.Add(u);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUsers", new { id = u.Id }, u);
//        }
//    }
//}