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
        [HttpGet("UserProfile")]
        [Authorize] // Ensure the user is authenticated
        public IActionResult GetLoggedInUserInfo()
        {
            // Retrieve the user's claims
            var claimsIdewdntity = User.Identity as ClaimsIdentity;
            if (claimsIdewdntity == null)
            {
                return Unauthorized();
            }

            // Extract relevant user information from claims
            var username = claimsIdewdntity.FindFirst(ClaimTypes.Name)?.Value;
            var email = claimsIdewdntity.FindFirst(ClaimTypes.Email)?.Value;
            var firstName = claimsIdewdntity.FindFirst(ClaimTypes.GivenName)?.Value;
            var lastName = claimsIdewdntity.FindFirst(ClaimTypes.Surname)?.Value;
            // Return the user information
            var userInfo = new
            {
                Username = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            return Ok(userInfo);
        }
    }
}