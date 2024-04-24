using System.ComponentModel.DataAnnotations;

namespace RollOnThePath_API.Models.Users
{
    public class UserSignUp
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
