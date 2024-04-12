using System.ComponentModel.DataAnnotations;

namespace RollOnThePath_API.Models
{
    public class Competition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Organizer { get; set; }

        [Required]
        public string MinimumBeltRecommendation { get; set; }

        // Foreign key
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
