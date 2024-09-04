using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RollOnThePath_API.Models.Users;
using RollOnThePath_API.Services.Users;
using System.Security.Claims;

namespace RollOnThePath_API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("UserProfile"), Authorize]
        public async Task<ActionResult<UserInfo>> GetUserProfile()
        {
            // Get the username from the JWT token
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (usernameClaim == null)
            {
                return Unauthorized();
            }
            var username = usernameClaim.Value;

            // Retrieve user information from the UserService
            var user = await _userService.GetUserByUsername(username);

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

        [HttpGet, Authorize]
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
        public async Task<ActionResult<IEnumerable<Models.Lessons.Lesson>>> GetUserLessons(int userId)
        {
            var lessons = await _userService.GetUserLessons(userId);

            // Configure JSON serializer settings
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };

            // Serialize lessons to JSON
            var json = JsonConvert.SerializeObject(lessons, serializerSettings);

            // Return JSON response
            return Content(json, "application/json");
        }

        [HttpPost("{userId}/add-lesson"), Authorize]
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

        [HttpPost, Authorize]
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

        [HttpGet("signupvalidation")]
        public async Task<IActionResult> CheckUserNameAndEmail([FromBody] UserSignUp userSignUp)
        {
            // Call the UserService method to check if the username or email already exists
            bool userExists = await _userService.CheckUserNameAndEmail(userSignUp);

            // Return true if username or email exists, false if not
            return Ok(userExists);
        }

    }
}