using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Services.Users
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string userId);
        Task<IEnumerable<Models.Lessons.Lesson>> GetUserLessons(int userId);
        Task<User> GetUserById(int id);
       Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task AddLessonToUser(int userId, int lessonId);
        Task<User> GetUserByUsername(string username);
        Task<bool> CheckUserNameAndEmail(UserSignUp userSignUp);
    }
}
