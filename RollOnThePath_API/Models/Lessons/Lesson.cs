using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Models.Lessons;

public class Lesson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;

    // Navigation property for LessonSections
    public List<LessonSection>? LessonSections { get; set; }

    // Navigation property for the many-to-many relationship with users
    public ICollection<UserLessons>? UserLessons { get; set; }

}
