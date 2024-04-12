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
    }
}

