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
        public DbSet<LessonSection> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Lessons)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Sections)
                .WithOne(ls => ls.Lesson)
                .HasForeignKey(ls => ls.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LessonSection>()
                .HasMany(ls => ls.SubLessons)
                .WithOne(sl => sl.LessonSection)
                .HasForeignKey(sl => sl.LessonSectionId)
                .OnDelete(DeleteBehavior.Cascade);

        }       
    }
}
