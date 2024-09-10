using RollWithIt.Models.Users;

namespace RollWithIt.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync();
    }
}
