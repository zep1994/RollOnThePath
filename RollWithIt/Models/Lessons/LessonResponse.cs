using System.Text.Json.Serialization;

namespace RollWithIt.Models.Lessons
{
    public class LessonResponse<T>
    {
        [JsonPropertyName("$id")]
        public string? Id { get; set; }

        [JsonPropertyName("$values")]
        public List<Lesson>? Values { get; set; }
    }

}
