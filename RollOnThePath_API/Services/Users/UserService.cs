using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models.Users;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RollOnThePath_API.Services.Users
{
    public class UserService(ApplicationDbContext dbContext) : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://10.0.2.2:5252";
        private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserInfo> GetUserInfoAsync(string userId)
        {
            // Set up your API endpoint URL
            var apiUrl = $"{_url}/api/users/{userId}";

            try
            {
                // Make authorized GET request to API endpoint
                var response = await _httpClient.GetAsync(apiUrl);

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read response content as string
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response to UserInfo object
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(responseBody);

                return userInfo;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            } catch (HttpRequestException ex)
            {
                throw new HttpRequestException("*** ERROR ***:", ex);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            // Get the user's ID from the JWT token
            //var userIdClaim = ((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            var userIdClaim = 2;
            if (userIdClaim == null)
            {
                throw new InvalidOperationException("User ID claim not found in JWT token.");
            }

            var userId = userIdClaim;
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task AddLessonToUser(int userId, int lessonId)
        {
            // Retrieve the user
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Retrieve the lesson
            var lesson = await _dbContext.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                throw new ArgumentException("Lesson not found");
            }

            // Check if the association already exists
            var existingAssociation = await _dbContext.UserLessons
                .FirstOrDefaultAsync(ul => ul.UserId == userId && ul.LessonId == lessonId);

            if (existingAssociation == null)
            {
                // If the association does not exist, create a new one
                var userLesson = new UserLessons
                {
                    UserId = userId,
                    LessonId = lessonId
                };

                _dbContext.UserLessons.Add(userLesson);
                await _dbContext.SaveChangesAsync();

                // Update the Lessons collection of the user
                user.Lessons.Add(lesson);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task RemoveLessonFromUser(int userId, int lessonId)
        {
            var userLesson = await _dbContext.UserLessons
                .SingleOrDefaultAsync(ul => ul.UserId == userId && ul.LessonId == lessonId);

            if (userLesson != null)
            {
                _dbContext.UserLessons.Remove(userLesson);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Models.Lessons.Lesson>> GetUserLessons(int userId)
        {
            try
            {
                var userLessons = await _dbContext.UserLessons
                    .Where(ul => ul.UserId == userId)
                    .Select(ul => ul.Lesson)
                    .ToListAsync();

                if (userLessons != null)
                {
                    return userLessons;
                } else
                {
                    throw new Exception("ERROR");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error occurred while retrieving user lessons", ex);
            }
        }

        public async Task<User> CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> CheckUserNameAndEmail(UserSignUp userSignUp)
        {
            // Check if username exists
            var userWithSameUserName = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == userSignUp.UserName);
            if (userWithSameUserName != null)
            {
                return true; // Username already exists
            }

            // Check if email exists
            var userWithSameEmail = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userSignUp.Email);
            if (userWithSameEmail != null)
            {
                return true; // Email already exists
            }

            return false; // Username and email are available
        }

    }
}