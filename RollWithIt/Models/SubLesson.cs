using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Models
{
    public class SubLesson
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public string? Objective { get; set; }
        public string? Difficulty { get; set; }
        public string? Notes { get; set; }
        public string? Activities { get; set; }
        public string? Resources { get; set; }

        // Foreign key property
        public int LessonSectionId { get; set; }
        // Navigation property for the related section
        public LessonSection? LessonSection { get; set; }
    }
}
