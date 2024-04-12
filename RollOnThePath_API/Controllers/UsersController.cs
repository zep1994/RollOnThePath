using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;
using RollOnThePath_API.Services;
using System.Security.Claims;

namespace RollOnThePath_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("UserProfile")]
        public async Task<ActionResult<UserInfo>> GetUserProfile()
        {
            // Get the username from the JWT token
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (usernameClaim == null)
            {
                return Unauthorized();
            }
            var username = usernameClaim.Value;

            // Retrieve user information from the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Map user information to UserInfo model
            var userInfo = new UserInfo
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BeltRank = user.BeltRank
            };

            return Ok(userInfo);
        }
    }
}