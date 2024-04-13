using RollOnThePath_API.Models;

namespace RollOnThePath_API.Services
{
    public interface IUserRepository
    {
        Task<UserInfo> GetUserInfo(string userId);
    }
}
