using SkillMasteryAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Application.Services.Interfaces;

public interface IGoalService
{
    Task<IEnumerable<Goal>> GetAllGoalsAsync();
    Task<Goal> GetGoalByIdAsync(int id);
    Task<Goal> AddGoalAsync(Goal goal);
    Task<Goal> UpdateGoalAsync(int id, Goal goal);
    Task<bool> DeleteGoalAsync(int id);
}