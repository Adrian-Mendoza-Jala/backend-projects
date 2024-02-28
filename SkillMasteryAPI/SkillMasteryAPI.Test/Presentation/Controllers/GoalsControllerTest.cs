using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using SkillMasteryAPI.Application.DTOs;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Presentation.Controllers;

namespace SkillMasteryAPI.Test.Presentation.Controllers;

public class GoalsControllerTests
{
    private readonly Mock<IGoalService> _mockGoalService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly GoalsController _controller;

    public GoalsControllerTests()
    {
        _mockGoalService = new Mock<IGoalService>();
        _mockMapper = new Mock<IMapper>();
        _controller = new GoalsController(_mockGoalService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetGoals_ReturnsAllGoals()
    {
        // Arrange
        var goals = new List<Goal> { new Goal(), new Goal() };
        var goalDtos = new List<GoalResponseDTO> { new GoalResponseDTO(), new GoalResponseDTO() };

        _mockGoalService.Setup(service => service.GetAllGoalsAsync()).ReturnsAsync(goals);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<GoalResponseDTO>>(goals)).Returns(goalDtos);

        // Act
        var result = await _controller.GetGoals();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(goalDtos, actionResult.Value);
    }

    [Fact]
    public async Task GetGoal_ReturnsGoal_WhenGoalExists()
    {
        // Arrange
        var goal = new Goal { Id = 1 };
        var goalDto = new GoalResponseDTO { Id = 1 };

        _mockGoalService.Setup(service => service.GetGoalByIdAsync(goal.Id)).ReturnsAsync(goal);
        _mockMapper.Setup(mapper => mapper.Map<GoalResponseDTO>(goal)).Returns(goalDto);

        // Act
        var result = await _controller.GetGoal(goal.Id);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(goalDto, actionResult.Value);
    }

    [Fact]
    public async Task GetGoal_ReturnsNotFound_WhenGoalDoesNotExist()
    {
        // Arrange
        _mockGoalService.Setup(service => service.GetGoalByIdAsync(It.IsAny<int>())).ReturnsAsync((Goal)null);

        // Act
        var result = await _controller.GetGoal(99);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PostGoal_CreatesAndReturnsGoal_WhenModelIsValid()
    {
        // Arrange
        var goalDto = new CreateGoalDTO();
        var goal = new Goal();
        var goalResponseDto = new GoalResponseDTO();

        _mockMapper.Setup(mapper => mapper.Map<Goal>(goalDto)).Returns(goal);
        _mockGoalService.Setup(service => service.AddGoalAsync(goal)).ReturnsAsync(goal);
        _mockMapper.Setup(mapper => mapper.Map<GoalResponseDTO>(goal)).Returns(goalResponseDto);

        // Act
        var result = await _controller.PostGoal(goalDto);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(goalResponseDto, actionResult.Value);
    }

    [Fact]
    public async Task PutGoal_UpdatesAndReturnsGoal_WhenGoalExists()
    {
        // Arrange
        var id = 1;
        var goalDto = new UpdateGoalDTO();
        var goal = new Goal { Id = id };
        var goalResponseDto = new GoalResponseDTO { Id = id };

        _mockGoalService.Setup(service => service.GetGoalByIdAsync(id)).ReturnsAsync(goal);
        _mockMapper.Setup(mapper => mapper.Map<Goal>(It.IsAny<UpdateGoalDTO>())).Returns(goal);
        _mockGoalService.Setup(service => service.UpdateGoalAsync(id, It.IsAny<Goal>())).ReturnsAsync(goal);
        _mockMapper.Setup(mapper => mapper.Map<GoalResponseDTO>(It.IsAny<Goal>())).Returns(goalResponseDto);

        // Act
        var result = await _controller.PutGoal(id, goalDto);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        var resultValue = actionResult.Value as GoalResponseDTO;

        resultValue.Should().BeEquivalentTo(goalResponseDto, options => options.ComparingByMembers<GoalResponseDTO>());
    }


    [Fact]
    public async Task DeleteGoal_ReturnsOk_WhenGoalIsDeleted()
    {
        // Arrange
        var id = 1;
        _mockGoalService.Setup(service => service.DeleteGoalAsync(id)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteGoal(id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var resultValue = okResult.Value;

        // Serialize the result value to JSON string for comparison
        var expectedJsonValue = JsonConvert.SerializeObject(new { Message = $"Goal with ID {id} was deleted." });
        var actualJsonValue = JsonConvert.SerializeObject(resultValue);

        Assert.Equal(expectedJsonValue, actualJsonValue);
    }


    [Fact]
    public async Task DeleteGoal_ReturnsNotFound_WhenGoalDoesNotExist()
    {
        // Arrange
        var id = 99;
        _mockGoalService.Setup(service => service.DeleteGoalAsync(id)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteGoal(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

}