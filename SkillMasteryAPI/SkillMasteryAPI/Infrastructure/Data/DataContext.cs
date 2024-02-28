using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Domain.Enums;

namespace SkillMasteryAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones de las entidades
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<Goal>(entity =>
            {
                entity.Property(e => e.Status)
                      .HasConversion<int>();
            });
            modelBuilder.Entity<Progress>().ToTable("Progresses");

            // Configurar la relación entre Goal y Skill
            modelBuilder.Entity<Goal>()
                .HasOne<Skill>(g => g.Skill)
                .WithMany()
                // .WithMany(s => s.Goals)
                .HasForeignKey(g => g.SkillId);

            // Configurar la relación entre Progress y Skill
            modelBuilder.Entity<Progress>()
                .HasOne<Skill>(p => p.Skill)
                .WithMany()
                .HasForeignKey(p => p.SkillId);

            // Seed initial data for Skill
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Programming", Description = "The ability to write computer programs" },
                new Skill { Id = 2, Name = "Design", Description = "The ability to create designs for user interfaces" },
                new Skill { Id = 3, Name = "Database", Description = "The ability to manage and maintain database management systems" }
            );

            // Seed initial data for Goals
            modelBuilder.Entity<Goal>().HasData(
                new Goal { Id = 1, SkillId = 1, Description = "Complete a basic programming course", Deadline = DateTime.SpecifyKind(new DateTime(2024, 12, 31), DateTimeKind.Utc), Status = Status.InProgress },
                new Goal { Id = 2, SkillId = 2, Description = "Design a user interface for a mobile app", Deadline = DateTime.SpecifyKind(new DateTime(2024, 06, 30), DateTimeKind.Utc), Status = Status.NotStarted },
                new Goal { Id = 3, SkillId = 3, Description = "Optimize database performance", Deadline = DateTime.SpecifyKind(new DateTime(2024, 09, 30), DateTimeKind.Utc), Status = Status.InProgress }
            );
        }
    }
}
