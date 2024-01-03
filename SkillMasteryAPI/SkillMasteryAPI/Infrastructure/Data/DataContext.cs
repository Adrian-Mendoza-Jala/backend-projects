using Microsoft.AspNetCore.Identity;
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

        // Identity tables
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
        public DbSet<IdentityUserToken<string>> UserTokens { get; set; }
        public DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // If you've renamed the ASP.NET Identity table names, configure them here as well
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            // Configuring Skill entity
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Programming", Description = "The ability to write computer programs" },
                new Skill { Id = 2, Name = "Design", Description = "The ability to create designs for user interfaces" },
                new Skill { Id = 3, Name = "Database", Description = "The ability to manage and maintain database management systems" }
            );
        }
    }
}
