using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollWithIt.Models.Lessons
{
    public class SubLesson
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? LessonSectionId { get; set; }
    }
}
