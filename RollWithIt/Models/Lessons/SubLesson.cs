using System.ComponentModel.DataAnnotations.Schema;

namespace RollWithIt.Models.Lessons
{
    public class SubLesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        [ForeignKey("LessonSectionId")]
        public int? LessonSectionId { get; set; }
    }
}
