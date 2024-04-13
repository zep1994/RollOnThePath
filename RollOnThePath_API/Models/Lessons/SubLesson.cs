namespace RollOnThePath_API.Models.Lessons
{
    public class SubLesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Objective {  get; set; } 
        public string? Difficulty { get; set; } = "Easy";
        public string? Notes { get; set; } = string.Empty;
        public string? Activities { get; set; }
        public string? Resources { get; set; }

        // Foreign key property
        public int LessonSectionId { get; set; }
        // Navigation property for the related section
        public LessonSection? LessonSection { get; set; }
    }
}
