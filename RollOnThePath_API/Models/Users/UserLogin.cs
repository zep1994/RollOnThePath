using System.ComponentModel.DataAnnotations;

namespace RollOnThePath_API.Models.Users
{
    public class UserLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
