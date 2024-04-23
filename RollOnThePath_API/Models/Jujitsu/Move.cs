namespace RollOnThePath_API.Models.Jujitsu
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public string SuggestedBelt { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Technique { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool LegalInCompetitionAtBelt { get; set; } = true;
    }
}