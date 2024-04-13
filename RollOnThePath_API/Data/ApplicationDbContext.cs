using Microsoft.EntityFrameworkCore;
using RollOnThePath_API.Models;
using RollOnThePath_API.Models.Lessons;


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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonSection> LessonSections { get; set; }
        public DbSet<SubLesson> SubLessons { get; set; }

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

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.User)            // Each lesson is owned by one user
                .WithMany(u => u.Lessons)      // Each user can have multiple lessons
                .HasForeignKey(l => l.UserId)  // Define the foreign key
                .OnDelete(DeleteBehavior.Restrict);

        }       
    }
}
