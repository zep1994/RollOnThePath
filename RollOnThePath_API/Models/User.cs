using RollOnThePath_API.Models.Lessons;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace RollOnThePath_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string? Username { get; set; }

        [Required]
        [EmailAddress]
        public required string? Email { get; set; }

        [Required]
        public required string? Password { get; set; }

        [StringLength(50)]
        public required string? FirstName { get; set; }

        [StringLength(50)]
        public required string LastName { get; set; }

        public bool? IsAdmin { get; set; } = false;

        public bool? IsCoach { get; set; } = false;

        public string? BeltRank { get; set; }

        public int? NumberOfStripes { get; set; } = 0;

        public int? TimeInTraining { get; set; } = 0;

        public List<string>? FavoriteTrainingDays { get; set; } = [];

        public string? Team { get; set; } = string.Empty;

        public string? Gym { get; set; } = string.Empty;

        public List<string>? Coaches { get; set; } = [];

        public ICollection<Competition>? Competitions { get; set; }
        public ICollection<Match>? Matches { get; set; }

        public ICollection<Lesson>? Lessons { get; set; }
    }
}