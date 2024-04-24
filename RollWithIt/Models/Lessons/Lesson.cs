using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RollWithIt.Models.Lessons
{
    public class Lesson
    {
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("Title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("LessonSections")]
        public List<LessonSection>? LessonSections { get; set; }

        [JsonPropertyName("UserLessons")]
        public ICollection<UserLessons>? UserLessons { get; set; }
    }
}
