using AspDotNetCoreMVCExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreMVCExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Abdur Rahim", Age = 20, Gender = "Male" },
                new Student { Id = 2, Name = "Alamin Mia", Age = 30, Gender = "Male" },
                new Student { Id = 3, Name = "Fatema Akter", Age = 22, Gender = "Female" }
            );
        }
    }
}
