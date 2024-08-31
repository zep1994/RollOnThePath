using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RollWithIt.Models.Lessons
{
    public class LessonResponse
    {
        [JsonPropertyName("$id")]
        public string? Id { get; set; }

        [JsonPropertyName("$values")]
        public List<Lesson>? Values { get; set; }
    }

}
