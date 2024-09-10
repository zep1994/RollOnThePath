using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RollWithIt.Models.Lessons
{
    public class Lesson
    {
        [Key]
        [JsonPropertyName("id")] // Ensure that this matches the JSON response
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")] // Ensure this matches the JSON response
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("lessonSections")]
        public List<LessonSection>? LessonSections { get; set; }
    }

}
