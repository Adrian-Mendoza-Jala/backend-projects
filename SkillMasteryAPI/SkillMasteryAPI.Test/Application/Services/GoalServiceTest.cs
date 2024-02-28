using Moq;
using Xunit;
using FluentAssertions;
using SkillMasteryAPI.Application.Services;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillMasteryAPI.Domain.Enums;

namespace SkillMasteryAPI.Test.Application.Services;

    public class GoalServiceTests
{
    private readonly Mock<IGoalRepository> _mockRepository;
    private readonly GoalService _goalService;

    public GoalServiceTests()
    {
        _mockRepository = new Mock<IGoalRepository>();
        _goalService = new GoalService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllGoalsAsync_ReturnsAllGoals()
    {
        // Arrange
        var goals = new List<Goal>
    {
        new Goal { Id = 1, Description = "Learn Unit Testing", Deadline = DateTime.Now.AddDays(30), Status = Status.NotStarted },
        new Goal { Id = 2, Description = "Complete Project X", Deadline = DateTime.Now.AddDays(60), Status = Status.InProgress }
    };
        _mockRepository.Setup(repo => repo.GetAllGoalsAsync()).ReturnsAsync(goals);

        // Act
        var result = await _goalService.GetAllGoalsAsync();

        // Assert
        result.Should().BeEquivalentTo(goals);
    }

    [Fact]
    public async Task GetGoalByIdAsync_ReturnsGoal_WhenGoalExists()
    {
        // Arrange
        var goal = new Goal { Id = 1, Description = "Learn Unit Testing", Deadline = DateTime.Now.AddDays(30), Status = Status.NotStarted };
        _mockRepository.Setup(repo => repo.GetGoalByIdAsync(goal.Id)).ReturnsAsync(goal);

        // Act
        var result = await _goalService.GetGoalByIdAsync(goal.Id);

        // Assert
        result.Should().BeEquivalentTo(goal);
    }

    [Fact]
    public async Task AddGoalAsync_ReturnsAddedGoal()
    {
        // Arrange
        var newGoal = new Goal { Description = "Learn Integration Testing", Deadline = DateTime.Now.AddDays(15), Status = Status.Pending };
        _mockRepository.Setup(repo => repo.AddGoalAsync(It.IsAny<Goal>())).Returns(Task.CompletedTask);

        // Act
        var result = await _goalService.AddGoalAsync(newGoal);

        // Assert
        result.Should().BeEquivalentTo(newGoal);
    }

    [Fact]
    public async Task UpdateGoalAsync_ReturnsUpdatedGoal_WhenGoalExists()
    {
        // Arrange
        var existingGoal = new Goal { Id = 1, Description = "Learn Unit Testing", Deadline = DateTime.Now.AddDays(30), Status = Status.NotStarted };
        var updatedGoal = new Goal { Id = 1, Description = "Learn Unit Testing - Updated", Deadline = DateTime.Now.AddDays(30), Status = Status.Completed };
        _mockRepository.Setup(repo => repo.GetGoalByIdAsync(existingGoal.Id)).ReturnsAsync(existingGoal);
        _mockRepository.Setup(repo => repo.UpdateGoalAsync(It.IsAny<Goal>())).Returns(Task.CompletedTask);

        // Act
        var result = await _goalService.UpdateGoalAsync(existingGoal.Id, updatedGoal);

        // Assert
        result.Should().NotBeNull();
        result.Description.Should().Be(updatedGoal.Description);
        result.Status.Should().Be(updatedGoal.Status);
    }

    [Fact]
    public async Task DeleteGoalAsync_ReturnsTrue_WhenGoalIsDeleted()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetGoalByIdAsync(It.IsAny<int>())).ReturnsAsync(new Goal());
        _mockRepository.Setup(repo => repo.DeleteGoalAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act
        var result = await _goalService.DeleteGoalAsync(1);

        // Assert
        result.Should().BeTrue();
    }

}
