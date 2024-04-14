using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<LessonSection>? Sections { get; set; } = new List<LessonSection>();
        public string? BeltRecommendation { get; set; } = "White";
        public string? Difficulty { get; set; } = "Easy";
        public bool? IsCompleted { get; set; } = false;
        // Foreign key property
        public int? UserId { get; set; }  // Nullable
        // Navigation property for the related user
        public User? User { get; set; }
    }
}
