using System.ComponentModel.DataAnnotations;

namespace RollOnThePath_API.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; }

        [Required]
        public string WeightDivision { get; set; }

        public string? BeltRanking { get; set; }

        public string? Gameplan { get; set; }

        public string? PostMatchNotes { get; set; }

        // Foreign key
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
