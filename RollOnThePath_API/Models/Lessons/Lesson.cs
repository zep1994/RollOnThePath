namespace RollOnThePath_API.Models.Lessons
{
    public class Lesson
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<LessonSection> Sections { get; set; }
    }
}
