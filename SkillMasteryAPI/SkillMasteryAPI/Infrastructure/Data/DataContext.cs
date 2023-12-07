using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().ToTable("Skills");

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Programming", Description = "The ability to write computer programs" },
                new Skill { Id = 2, Name = "Design", Description = "The ability to create designs for user interfaces" },
                new Skill { Id = 3, Name = "Database", Description = "The ability to manage and maintain database management systems" }
            );
        }
    }
}
