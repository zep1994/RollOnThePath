namespace RollOnThePath_API.Models.Lessons
{
    public class LessonSection
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool? IsCompleted { get; set; } = false;
        public string? Focus { get; set; } = string.Empty;
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public List<SubLesson>? SubLessons { get; set; } = new List<SubLesson>();
    }
}
