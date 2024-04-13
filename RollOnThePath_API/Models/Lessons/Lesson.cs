namespace RollOnThePath_API.Models.Lessons
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? BeltRecommendation { get; set; }
        public string? Difficulty { get; set; }
        public bool? IsCompleted { get; set; }

        // Navigation property for related sections
        public List<LessonSection>? Sections { get; set; }
    }
}
