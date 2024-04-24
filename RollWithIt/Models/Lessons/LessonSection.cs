using System.Text.Json.Serialization;

namespace RollWithIt.Models.Lessons
{
    public class LessonSection
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Lesson")]
        public Lesson? Lesson { get; set; }

        [JsonPropertyName("LessonId")]
        public int LessonId { get; set; }

        [JsonPropertyName("SubLessons")]
        public List<SubLesson>? SubLessons { get; set; }
    }
}
