namespace RollOnThePath_API.Models.Lessons
{
    public class Lesson
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime? Date { get; set; }
        public string? BeltRecommendation { get; set; }
        public string? Difficulty { get; set; }
        public bool? IsCompleted { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        // Navigation property for related sections
        public List<LessonSection>? Sections { get; set; }
    }
}
