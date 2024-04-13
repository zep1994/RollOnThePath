namespace RollOnThePath_API.Models.Lessons
{
    public class LessonSection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public string? Focus { get; set; }

        public List<SubLesson>? SubLessons { get; set; }
        public int? LessonId { get; set; } // Foreign key for lesson
        public Lesson? Lesson { get; set; } // Navigation property for lesson
    }
}
