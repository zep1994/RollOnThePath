using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Models
{
    public class Lesson
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<LessonSection>? Sections { get; set; }
        public string? BeltRecommendation { get; set; }
        public string? Difficulty { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
