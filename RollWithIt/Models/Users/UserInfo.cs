using System.Text.Json.Serialization;

namespace RollWithIt.Models.Users
{
    public class UserInfo
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("beltRank")]
        public string? BeltRank { get; set; }
    }
}
