﻿using System.ComponentModel.DataAnnotations;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Models.Lessons;

public class Lesson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;

    public string Belt { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Difficulty { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<LessonSection>? LessonSections { get; set; }
    public ICollection<UserLessons>? UserLessons { get; set; }

}
