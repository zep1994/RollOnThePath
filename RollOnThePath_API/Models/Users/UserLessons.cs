using RollOnThePath_API.Models.Lessons;
using System.ComponentModel.DataAnnotations.Schema;

namespace RollOnThePath_API.Models.Users
{
    public class UserLessons
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
