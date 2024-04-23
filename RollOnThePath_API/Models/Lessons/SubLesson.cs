using System.ComponentModel.DataAnnotations.Schema;

namespace RollOnThePath_API.Models.Lessons;

public class SubLesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // Foreign key property for LessonSection
    public int LessonSectionId { get; set; }

    // Navigation property for LessonSection
    [ForeignKey("LessonSectionId")]
    public LessonSection? LessonSection { get; set; }
}
