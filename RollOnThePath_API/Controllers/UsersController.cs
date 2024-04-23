using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;
using RollOnThePath_API.Models.Users;
using RollOnThePath_API.Services;
using RollOnThePath_API.Services.Users;
using System.Security.Claims;

namespace RollOnThePath_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        //[Authorize]
        //[HttpGet("UserProfile")]
        //public async Task<ActionResult<UserInfo>> GetUserProfile()
        //{
        //    // Get the username from the JWT token
        //    var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
        //    if (usernameClaim == null)
        //    {
        //        return Unauthorized();
        //    }
        //    var username = usernameClaim.Value;

        //    // Retrieve user information from the UserService
        //    var user = await _userService.GetUserByUsername(username);

        //    if (user == null)
        //    {
        //        return NotFound("User not found");
        //    }

        //    // Map user information to UserInfo model
        //    var userInfo = new UserInfo
        //    {
        //        Username = user.Username,
        //        Email = user.Email,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        BeltRank = user.BeltRank
        //    };

        //    return Ok(userInfo);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{userId}/lessons")]
        public async Task<IActionResult> GetUserLessons(int userId)
        {
            var lessons = await _userService.GetUserLessons(userId);
            return Ok(lessons);
        }

        [HttpPost("{userId}/add-lesson")]
        public async Task<IActionResult> AddLessonToUser(int userId, [FromBody] UserLessons request)
        {
            try
            {
                await _userService.AddLessonToUser(userId, request.LessonId);
                return Ok("Lesson added to user successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}