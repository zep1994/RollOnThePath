using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Models;


namespace RollOnThePath_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Move> Moves {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define any additional configurations or relationships here if needed

            // Example: Define the relationship between User and Competition
            modelBuilder.Entity<Competition>()
                .HasOne(c => c.User)
                .WithMany(u => u.Competitions)
                .HasForeignKey(c => c.UserId);
        }
    }
}

