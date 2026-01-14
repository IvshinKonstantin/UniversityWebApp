using Microsoft.EntityFrameworkCore;
using UniversityWebApp.Models;

namespace UniversityWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Простые связи для начала
            base.OnModelCreating(modelBuilder);
        }
    }
}
