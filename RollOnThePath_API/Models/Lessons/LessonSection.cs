namespace RollOnThePath_API.Models.Lessons
{
    public class LessonSection
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SubLesson> SubLessons { get; set; }
    }
}
