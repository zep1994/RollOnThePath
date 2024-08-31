using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RollWithIt.Models.Lessons
{
    public class Lesson
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("lessonSections")]
        public List<LessonSection>? LessonSections { get; set; }

        [JsonPropertyName("userLessons")]
        public ICollection<UserLessons>? UserLessons { get; set; }
    }
}
