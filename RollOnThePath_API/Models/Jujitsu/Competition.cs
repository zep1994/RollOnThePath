using System.ComponentModel.DataAnnotations;
using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Models.Jujitsu
{
    public class Competition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime? DateTime { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Organizer { get; set; } = string.Empty;

        [Required]
        public string MinimumBeltRecommendation { get; set; } = string.Empty;

        // Foreign key
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Match> Matches { get; set; } = [];

    }
}
