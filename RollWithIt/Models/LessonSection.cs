using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Models
{
    public class LessonSection
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsCompleted { get; set; }
        public string? Focus { get; set; }

        // Foreign key property
        public int LessonId { get; set; }

        // Navigation property for the related lesson
        public Lesson? Lesson { get; set; }

        // Navigation property for related sub-lessons
        public List<SubLesson>? SubLessons { get; set; }

        // Add the IsExpanded property
        public bool? IsExpanded { get; set; }
    }
}
