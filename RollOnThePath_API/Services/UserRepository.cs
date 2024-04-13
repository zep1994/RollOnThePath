using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;

namespace RollOnThePath_API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserInfo> GetUserInfo(string userId)
        {
            // Implement your logic to fetch user info from the database based on userId
            // For demonstration purposes, let's assume you have a User entity in your DbContext

            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                // User not found
                return null;
            }

            // Map User entity to UserInfo object
            var userInfo = new UserInfo
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BeltRank = user.BeltRank
            };

            return userInfo;
        }
    }
}