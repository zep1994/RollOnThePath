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
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public bool? IsAdmin { get; set; } = false;

        public bool? IsCoach { get; set; } = false;

        public string? BeltRank { get; set; }

        public int? NumberOfStripes { get; set; } = 0;

        public int? TimeInTraining { get; set; } = 0;

        public List<string>? FavoriteTrainingDays { get; set; } = new List<string>();

        public string? Team { get; set; } = string.Empty;

        public string? Gym { get; set; } = string.Empty;

        public List<string>? Coaches { get; set; } = new List<string>();

        public ICollection<Competition>? Competitions { get; set; }
        public ICollection<Match>? Matches { get; set; }

        public ICollection<Lesson>? Lessons { get; set; } = new List<Lesson>();
    }
}