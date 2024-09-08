using System.ComponentModel.DataAnnotations;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Models.Lessons;

public class Lesson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;

    // New properties
    public string Belt { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Difficulty { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int UserId { get; set; }
    // Navigation property for LessonSections
    public List<LessonSection>? LessonSections { get; set; }

    // Navigation property for the many-to-many relationship with users
    public ICollection<UserLessons>? UserLessons { get; set; }

}
