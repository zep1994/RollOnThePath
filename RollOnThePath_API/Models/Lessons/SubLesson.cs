namespace RollOnThePath_API.Models.Lessons
{
    public class SubLesson
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Objective {  get; set; } 
        public string? Difficulty { get; set; } = "Easy";
        public string? Notes { get; set; } = string.Empty;
        public string? Activities { get; set; }
        public string? Resources { get; set; }

        // Foreign key property
        public required int LessonSectionId { get; set; }
        // Navigation property for the related section
        public LessonSection? LessonSection { get; set; }
    }
}
