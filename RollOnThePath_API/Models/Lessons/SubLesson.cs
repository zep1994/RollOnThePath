namespace RollOnThePath_API.Models.Lessons
{
    public class SubLesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool? IsCompleted { get; set; } = false;
        public string? Objective { get; set; } = string.Empty;
        public string? Difficulty { get; set; } = "Easy";
        public string? Notes { get; set; } = string.Empty;
        public string[]? Activities { get; set; } = Array.Empty<string>();
        public string? Resources { get; set; } = string.Empty;
        // Foreign key property
        public int LessonSectionId { get; set; }
        // Navigation property for the related section
        public LessonSection? LessonSection { get; set; }
    }
}
