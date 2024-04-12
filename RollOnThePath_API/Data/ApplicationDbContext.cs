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
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.Competitions)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Competition>()
            .HasMany(c => c.Matches)
            .WithOne(m => m.Competition)  // Use the navigation property here
            .HasForeignKey(m => m.CompetitionId);

            base.OnModelCreating(modelBuilder);

        }
    }
}

