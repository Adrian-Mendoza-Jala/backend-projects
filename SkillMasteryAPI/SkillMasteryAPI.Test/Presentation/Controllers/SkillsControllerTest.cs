using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Presentation.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkillMasteryAPI.Test.Presentation.Controllers;

public class SkillsControllerTests
{
    private readonly Mock<ISkillService> _mockSkillService;
    private readonly SkillsController _controller;

    public SkillsControllerTests()
    {
        _mockSkillService = new Mock<ISkillService>();
        _controller = new SkillsController(_mockSkillService.Object);
    }

    [Fact]
    public async Task GetSkills_ReturnsAllSkills()
    {
        // Arrange
        var skills = new List<Skill> { new Skill(), new Skill() };
        _mockSkillService.Setup(s => s.GetAllSkillsAsync()).ReturnsAsync(skills);

        // Act
        var result = await _controller.GetSkills();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(skills, actionResult.Value);
    }

    [Fact]
    public async Task PostSkill_ReturnsCreatedAtAction_WhenModelIsValid()
    {
        // Arrange
        var skill = new Skill { Name = "Test Skill", Description = "Test Description" };
        _mockSkillService.Setup(s => s.AddSkillAsync(It.IsAny<Skill>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.PostSkill(skill);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(skill, actionResult.Value);
    }

    [Fact]
    public async Task GetSkill_ReturnsSkill_WhenSkillExists()
    {
        // Arrange
        var skill = new Skill { Id = 1, Name = "Test Skill", Description = "Test Description" };
        _mockSkillService.Setup(s => s.GetSkillByIdAsync(skill.Id)).ReturnsAsync(skill);

        // Act
        var result = await _controller.GetSkill(skill.Id);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(skill, actionResult.Value);
    }

    [Fact]
    public async Task PutSkill_ReturnsOk_WhenSkillExists()
    {
        // Arrange
        var skill = new Skill { Id = 1, Name = "Updated Skill", Description = "Updated Description" };
        _mockSkillService.Setup(s => s.GetSkillByIdAsync(skill.Id)).ReturnsAsync(skill);
        _mockSkillService.Setup(s => s.UpdateSkillAsync(It.IsAny<Skill>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.PutSkill(skill.Id, skill);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task DeleteSkill_ReturnsOk_WhenSkillIsDeleted()
    {
        // Arrange
        var skillId = 1;
        _mockSkillService.Setup(s => s.SkillExists(skillId)).Returns(true);
        _mockSkillService.Setup(s => s.DeleteSkillAsync(skillId)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteSkill(skillId);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        var resultValue = JsonConvert.SerializeObject(actionResult.Value);
        var expectedValue = JsonConvert.SerializeObject(new { Message = $"Skill with ID {skillId} was deleted." });
        Assert.Equal(expectedValue, resultValue);
    }


    [Fact]
    public async Task GetPaginatedSkills_ReturnsPaginatedResults()
    {
        // Arrange
        var skills = new List<Skill> { new Skill(), new Skill() };
        var pageNumber = 1;
        var pageSize = 10;
        _mockSkillService.Setup(s => s.GetPaginatedSkillsAsync(pageNumber, pageSize)).ReturnsAsync(skills);
        _mockSkillService.Setup(s => s.GetTotalCountAsync()).ReturnsAsync(20);

        // Act
        var result = await _controller.GetPaginatedSkills(pageNumber, pageSize);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var actualResponse = actionResult.Value;

        var expectedResponse = new
        {
            TotalCount = 20,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling((double)20 / pageSize),
            Skills = skills
        };

        var expectedJson = JsonConvert.SerializeObject(expectedResponse);
        var actualJson = JsonConvert.SerializeObject(actualResponse);
        Assert.Equal(expectedJson, actualJson);
    }


}
