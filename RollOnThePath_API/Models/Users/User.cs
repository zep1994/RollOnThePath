using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using RollOnThePath_API.Models.Jujitsu;
using RollOnThePath_API.Models.Lessons;

namespace RollOnThePath_API.Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public bool? IsAdmin { get; set; } = false;

        public bool? IsCoach { get; set; } = false;

        public string BeltRank { get; set; } = "White";

        public int? NumberOfStripes { get; set; } = 0;

        public int? TimeInTraining { get; set; } = 0;

        public List<string>? FavoriteTrainingDays { get; set; } = [];

        public string? Team { get; set; } = string.Empty;

        public string? Gym { get; set; } = string.Empty;

        public List<string>? Coaches { get; set; } = [];

        public ICollection<UserLessons>? UserLessons { get; set; } = []; // Navigation property for user-lesson relationship

        public ICollection<Lesson> Lessons { get; set; } = [];

        public ICollection<Competition>? Competitions { get; set; } = [];

        public ICollection<Match>? Matches { get; set; } = [];
    }
}