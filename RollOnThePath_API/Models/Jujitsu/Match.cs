using RollOnThePath_API.Models.Users;

namespace RollOnThePath_API.Models.Jujitsu
{
    public class Match
    {
        public int Id { get; set; }

        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public string WeightDivision { get; set; } = string.Empty;
        public string BeltRanking { get; set; } = string.Empty;
        public string Gameplan { get; set; } = string.Empty;
        public string PostMatchNotes { get; set; } = string.Empty;

        // Foreign key
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
