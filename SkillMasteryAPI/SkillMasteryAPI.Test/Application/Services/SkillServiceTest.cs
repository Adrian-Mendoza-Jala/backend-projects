using System;
using SkillMasteryAPI.Application.Services;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;
using Xunit;
using Moq;

namespace SkillMasteryAPI.Test.Application.Services
{
    public class SkillServiceTests
    {
        private readonly Mock<ISkillRepository> _mockRepo;
        private readonly SkillService _skillService;

        public SkillServiceTests()
        {
            _mockRepo = new Mock<ISkillRepository>();
            _skillService = new SkillService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllSkillsAsync_ReturnsAllSkills()
        {
            // Arrange
            var expectedSkills = new List<Skill> { new Skill { Id = 1, Name = "Skill1", Description = "Desc1" }, new Skill { Id = 2, Name = "Skill2", Description = "Desc2" } };
            _mockRepo.Setup(repo => repo.GetAllSkillsAsync()).ReturnsAsync(expectedSkills);

            // Act
            var result = await _skillService.GetAllSkillsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSkills.Count, result.Count());
            Assert.Equal(expectedSkills, result);
        }

        [Fact]
        public async Task GetSkillByIdAsync_ReturnsSkill_WhenSkillExists()
        {
            // Arrange
            var skillId = 1;
            var expectedSkill = new Skill { Id = skillId, Name = "Test Skill", Description = "Test Description" };
            _mockRepo.Setup(repo => repo.GetSkillByIdAsync(skillId)).ReturnsAsync(expectedSkill);

            // Act
            var result = await _skillService.GetSkillByIdAsync(skillId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSkill.Id, result.Id);
            Assert.Equal(expectedSkill.Name, result.Name);
            Assert.Equal(expectedSkill.Description, result.Description);
        }

        [Fact]
        public async Task AddSkillAsync_CallsRepositoryWithSkill()
        {
            // Arrange
            var newSkill = new Skill { Name = "New Skill", Description = "New Description" };
            _mockRepo.Setup(repo => repo.AddSkillAsync(newSkill)).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _skillService.AddSkillAsync(newSkill);

            // Assert
            _mockRepo.Verify(repo => repo.AddSkillAsync(newSkill), Times.Once);
        }

        [Fact]
        public async Task UpdateSkillAsync_CallsRepositoryWithSkill()
        {
            // Arrange
            var existingSkill = new Skill { Id = 1, Name = "Existing Skill", Description = "Existing Description" };
            _mockRepo.Setup(repo => repo.UpdateSkillAsync(existingSkill)).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _skillService.UpdateSkillAsync(existingSkill);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateSkillAsync(existingSkill), Times.Once);
        }

        [Fact]
        public async Task DeleteSkillAsync_DeletesSkill_WhenSkillExists()
        {
            // Arrange
            var skillId = 1;
            var existingSkill = new Skill { Id = skillId, Name = "Existing Skill", Description = "Existing Description" };
            _mockRepo.Setup(repo => repo.GetSkillByIdAsync(skillId)).ReturnsAsync(existingSkill);
            _mockRepo.Setup(repo => repo.DeleteSkillAsync(existingSkill)).Returns(Task.CompletedTask).Verifiable();

            // Act
            await _skillService.DeleteSkillAsync(skillId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteSkillAsync(existingSkill), Times.Once);
        }



        [Fact]
        public async Task GetPaginatedSkillsAsync_ReturnsCorrectPageSize()
        {
            // Arrange
            int pageNumber = 1;
            int pageSize = 2;
            var paginatedSkills = new List<Skill>
            {
                new Skill { Id = 1, Name = "Skill1", Description = "Description1" },
                new Skill { Id = 2, Name = "Skill2", Description = "Description2" },
                new Skill { Id = 3, Name = "Skill3", Description = "Description3" }
            };

            _mockRepo.Setup(repo => repo.GetPaginatedSkillsAsync(pageNumber, pageSize))
                .ReturnsAsync(paginatedSkills.Take(pageSize).ToList());

            // Act
            var result = await _skillService.GetPaginatedSkillsAsync(pageNumber, pageSize);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pageSize, result.Count());
            Assert.All(result, skill => paginatedSkills.Select(s => s.Id).Contains(skill.Id));
        }


        [Fact]
        public async Task GetTotalCountAsync_ReturnsTotalSkillCount()
        {
            // Arrange
            var totalCount = 42;
            _mockRepo.Setup(repo => repo.GetTotalCountAsync()).ReturnsAsync(totalCount);

            // Act
            var result = await _skillService.GetTotalCountAsync();

            // Assert
            Assert.Equal(totalCount, result);
        }


    }

}
