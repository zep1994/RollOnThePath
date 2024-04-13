using RollOnThePath_API.Models;

namespace RollOnThePath_API.Services
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string userId);
    }
}
