namespace RollOnThePath_API.Models.Lessons
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<LessonSection>? Sections { get; set; } = new List<LessonSection>();
        public string? BeltRecommendation { get; set; } = "White";
        public string? Difficulty { get; set; } = "Easy";
        public bool? IsCompleted { get; set; } = false;
        // Foreign key property
        public int? UserId { get; set; }  // Nullable
        // Navigation property for the related user
        public User? User { get; set; }
    }
}
