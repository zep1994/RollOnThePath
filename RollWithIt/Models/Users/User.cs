﻿namespace RollWithIt.Models.Users
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsCoach { get; set; }
        public string? BeltRank { get; set; }
        public int? NumberOfStripes { get; set; }
        public int? TimeInTraining { get; set; }
        public List<string>? FavoriteTrainingDays { get; set; }
        public string? Team { get; set; }
        public string? Gym { get; set; }
        public List<string>? Coaches { get; set; }
    }
}
