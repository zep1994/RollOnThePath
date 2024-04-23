using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RollOnThePath_API.Models.Lessons;

public class LessonSection
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    // Foreign key property
    public int LessonId { get; set; }

    // Navigation property
    [ForeignKey("LessonId")]
    [JsonIgnore]
    public Lesson? Lesson { get; set; }

    // Navigation property for SubLessons
    public List<SubLesson>? SubLessons { get; set; }
}
