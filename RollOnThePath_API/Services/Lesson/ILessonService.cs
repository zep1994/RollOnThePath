using RollOnThePath_API.Models.Lessons;

namespace RollOnThePath_API.Services.Lesson
{
    public interface ILessonService
    {
        Task<List<Models.Lessons.Lesson>> GetAllLessons();
        Task<Models.Lessons.Lesson> GetLessonById(int id);
        Task AddLesson(Models.Lessons.Lesson lesson);
        Task<LessonSection> CreateLessonSection(int lessonId, LessonSection sectionModel);
        Task<LessonSection> GetLessonSection(int id);
        Task<SubLesson> CreateSubLesson(int sectionId, SubLesson subLesson);

    }
}
