using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RollOnThePath_API.Models.Jujitsu;
using RollOnThePath_API.Models.Lessons;
using RollOnThePath_API.Models.Users;


namespace RollOnThePath_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
        }

        public DbSet<Move> Moves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonSection> LessonsSection { get; set; }
        public DbSet<SubLesson> SubLessons { get; set; }
        public DbSet<UserLessons> UserLessons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Competitions)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Matches)
                .WithOne(m => m.Competition)
                .HasForeignKey(m => m.CompetitionId);


            modelBuilder.Entity<UserLessons>()
            .HasKey(ul => new { ul.UserId, ul.LessonId });

            modelBuilder.Entity<UserLessons>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<UserLessons>()
                .HasOne(ul => ul.Lesson)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(ul => ul.LessonId);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.LessonSections)
                .WithOne(ls => ls.Lesson)
                .HasForeignKey(ls => ls.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LessonSection>()
                .HasMany(ls => ls.SubLessons)
                .WithOne(sl => sl.LessonSection)
                .HasForeignKey(sl => sl.LessonSectionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

        }
    }
}

