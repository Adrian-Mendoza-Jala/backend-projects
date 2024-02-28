using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Data;
using SkillMasteryAPI.Infrastructure.Repositories.Implementations;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SkillMasteryAPI.Test.Infrastructure.Repositories;

public class GoalRepositoryTests : IDisposable
{
    private readonly DataContext _context;

    public GoalRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new DataContext(options);

        SeedDatabase();
    }

    private DataContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new DataContext(options);
    }


    private void SeedDatabase()
    {
        if (!_context.Goals.Any())
        {
            _context.Goals.AddRange(
                new Goal { Id = 1, Description = "Test Goal 1", SkillId = 1 },
                new Goal { Id = 2, Description = "Test Goal 2", SkillId = 2 }
            );
            _context.SaveChanges();
        }
    }

    [Fact]
    public async Task GetAllGoalsAsync_ReturnsAllGoals()
    {
        // Arrange
        var repository = new GoalRepository(_context);

        // Act
        var goals = await repository.GetAllGoalsAsync();

        // Assert
        Assert.Equal(2, goals.Count());
    }

    [Fact]
    public async Task GetGoalByIdAsync_ReturnsCorrectGoal()
    {
        // Arrange
        var repository = new GoalRepository(_context);
        var expectedId = 1;

        // Act
        var goal = await repository.GetGoalByIdAsync(expectedId);

        // Assert
        Assert.NotNull(goal);
        Assert.Equal(expectedId, goal.Id);
    }

    [Fact]
    public async Task AddGoalAsync_AddsGoalSuccessfully()
    {
        // Arrange
        var repository = new GoalRepository(_context);
        var newGoal = new Goal { Description = "New Goal", SkillId = 3 };

        // Act
        await repository.AddGoalAsync(newGoal);
        var addedGoal = await _context.Goals.FirstOrDefaultAsync(g => g.Description == newGoal.Description);

        // Assert
        Assert.NotNull(addedGoal);
        Assert.Equal(newGoal.Description, addedGoal.Description);
    }

    [Fact]
    public async Task UpdateGoalAsync_UpdatesGoalSuccessfully()
    {
        // Arrange
        var repository = new GoalRepository(_context);
        var goalToUpdate = new Goal { Id = 3, Description = "Initial Goal", SkillId = 1 };
        _context.Goals.Add(goalToUpdate);
        _context.SaveChanges();

        goalToUpdate.Description = "Updated Goal";

        // Act
        await repository.UpdateGoalAsync(goalToUpdate);
        var updatedGoal = await _context.Goals.FindAsync(goalToUpdate.Id);

        // Assert
        Assert.NotNull(updatedGoal);
        Assert.Equal("Updated Goal", updatedGoal.Description);
    }

    [Fact]
    public async Task DeleteGoalAsync_DeletesGoalSuccessfully()
    {
        // Arrange
        var repository = new GoalRepository(_context);
        var goalIdToDelete = 1;

        // Act
        await repository.DeleteGoalAsync(goalIdToDelete);

        // Create a new context for verification
        using var verifyContext = CreateContext();
        var deletedGoal = await verifyContext.Goals.FindAsync(goalIdToDelete);

        // Assert
        Assert.Null(deletedGoal);
    }


    [Fact]
    public async Task GoalExistsAsync_ReturnsTrue_WhenGoalExists()
    {
        // Arrange
        var repository = new GoalRepository(_context);
        var goalId = 1;

        // Act
        var exists = await repository.GoalExistsAsync(goalId);

        // Assert
        Assert.True(exists);
    }

    public void Dispose()
    {
        // Clean up the context resources
        _context.Dispose();
    }
}