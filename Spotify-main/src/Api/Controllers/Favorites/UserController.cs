﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Core.Data;
using Spotify.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Api.Controllers
{
    [Route("api/[Controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FeaturifyContext _context;
        public UserController(FeaturifyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<Users>> GetUsers()
        {
            var response = _context.Users.ToListAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserByID(int id)
        {
            var response = await _context.Users.FindAsync(id);
            return response == null ? NotFound() : response;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }
    }
}