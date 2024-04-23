using Microsoft.AspNetCore.Mvc;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Services.Users
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string userId);
        Task<List<Models.Lessons.Lesson>> GetUserLessons(int userId); // Add this method
        Task<User> GetUserById(int id);
       Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task AddLessonToUser(int userId, int lessonId);
    }
}
