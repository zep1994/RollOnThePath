using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace RollOnThePath_API.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsCoach { get; set; }

        public string? BeltRank { get; set; }

        public int? NumberOfStripes { get; set; }

        public int? TimeInTraining { get; set; } 

        public List<string>? FavoriteTrainingDays { get; set; }

        public string? Team { get; set; }

        public string? Gym { get; set; }

        public List<string>? Coaches { get; set; }

        public ICollection<Competition> Competitions { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}