using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Data;
using SkillMasteryAPI.Infrastructure.Repositories.Implementations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SkillMasteryAPI.Test.Infrastructure.Repositories;

public class SkillRepositoryTests : IDisposable
{
    private readonly DataContext _context;
    private readonly SkillRepository _repository;

    public SkillRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
        _repository = new SkillRepository(_context);

        SeedDatabase();
    }

    private void SeedDatabase()
    {
        var skills = new[]
        {
                new Skill { Name = "C#", Description = "Programming Language" },
                new Skill { Name = "JavaScript", Description = "Scripting Language" }
            };

        _context.Skills.AddRange(skills);
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetAllSkillsAsync_ReturnsAllSkills()
    {
        // Act
        var results = await _repository.GetAllSkillsAsync();

        // Assert
        Assert.Equal(2, await _context.Skills.CountAsync());
        Assert.NotEmpty(results);
    }

    [Fact]
    public async Task GetSkillByIdAsync_ReturnsCorrectSkill_WhenSkillExists()
    {
        // Arrange
        var expectedSkill = await _context.Skills.FirstOrDefaultAsync();
        Assert.NotNull(expectedSkill);

        // Act
        var result = await _repository.GetSkillByIdAsync(expectedSkill.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedSkill.Name, result.Name);
    }

    [Fact]
    public async Task AddSkillAsync_AddsSkillSuccessfully()
    {
        // Arrange
        var newSkill = new Skill { Name = "Python", Description = "Interpreted Language" };

        // Act
        await _repository.AddSkillAsync(newSkill);
        var addedSkill = await _context.Skills.FirstOrDefaultAsync(s => s.Name == "Python");

        // Assert
        Assert.NotNull(addedSkill);
        Assert.Equal("Python", addedSkill.Name);
    }

    [Fact]
    public async Task UpdateSkillAsync_UpdatesSkillCorrectly()
    {
        // Arrange
        var skillToUpdate = await _context.Skills.FirstOrDefaultAsync();
        Assert.NotNull(skillToUpdate);
        skillToUpdate.Description = "Updated Description";

        // Act
        await _repository.UpdateSkillAsync(skillToUpdate);
        var updatedSkill = await _context.Skills.FindAsync(skillToUpdate.Id);

        // Assert
        Assert.NotNull(updatedSkill);
        Assert.Equal("Updated Description", updatedSkill.Description);
    }

    [Fact]
    public async Task DeleteSkillAsync_DeletesSkillSuccessfully()
    {
        // Arrange
        var skillToDelete = await _context.Skills.FirstOrDefaultAsync();
        Assert.NotNull(skillToDelete);

        // Act
        await _repository.DeleteSkillAsync(skillToDelete.Id);
        var deletedSkill = await _context.Skills.FindAsync(skillToDelete.Id);

        // Assert
        Assert.Null(deletedSkill);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}

