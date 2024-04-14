using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Data;
using RollOnThePath_API.Models;

namespace RollOnThePath_API.Services
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<UserInfo> GetUserInfo(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) { throw new ArgumentNullException("user"); }

            var userInfo = new UserInfo
            {
                Username = user?.Username ?? "Not Found",
                Email = user?.Email ?? "Not Found",
                FirstName = user?.FirstName ?? "Not Found",
                LastName = user?.LastName ?? "Not Found",
            };

            return userInfo;

        }
    }
}