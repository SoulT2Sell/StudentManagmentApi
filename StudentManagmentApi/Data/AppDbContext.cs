using Microsoft.EntityFrameworkCore;
using StudentManagmentApi.Models;

namespace StudentManagmentApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(s => s.Email)
                .IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
