namespace RollOnThePath_API.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string SuggestedBelt { get; set; }
        public string Type { get; set; }
        public string Technique { get; set; }
        public string Position { get; set; }
        public bool LegalInCompetitionAtBelt { get; set; }
    }
}