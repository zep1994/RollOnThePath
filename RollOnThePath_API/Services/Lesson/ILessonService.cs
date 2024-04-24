using RollOnThePath_API.Models.Lessons;

namespace RollOnThePath_API.Services.Lesson
{
    public interface ILessonService
    {
        Task<List<Models.Lessons.Lesson>> GetAllLessons();
        Task<Models.Lessons.Lesson> GetLessonById(int id);
        Task AddLesson(Models.Lessons.Lesson lesson);
        Task<LessonSection> CreateLessonSection(int lessonId, LessonSection sectionModel);
        Task<List<LessonSection>> GetLessonSectionsAsync(int lessonId);
        Task<SubLesson> CreateSubLesson(int sectionId, SubLesson subLesson);
        Task<List<SubLesson>> GetSubLessonsAsync(int lessonSectionId);

    }
}
