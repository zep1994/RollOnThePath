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
        public List<SubLesson> SubLessons { get; set; }
        public string SectionTitle => Title;

        // Add the IsExpanded property
        public bool IsExpanded { get; set; }
    }
}
