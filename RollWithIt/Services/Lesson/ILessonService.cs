using RollWithIt.Models.Lessons;

namespace RollWithIt.Services.Lesson
{
    public interface ILessonService
    {
        Task<List<Models.Lessons.Lesson>?> GetUserLessonsAsync();
        Task<List<LessonSection>?> GetLessonSectionsAsync(string lessonId);
        Task<List<LessonSection>> GetSectionsByLessonId(int lessonId);
    }
}
