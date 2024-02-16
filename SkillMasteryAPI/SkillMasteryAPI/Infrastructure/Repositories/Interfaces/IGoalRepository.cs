using SkillMasteryAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Infrastructure.Repositories.Interfaces;
public interface IGoalRepository
{
    Task<IEnumerable<Goal>> GetAllGoalsAsync();
    Task<Goal> GetGoalByIdAsync(int id);
    Task AddGoalAsync(Goal goal);
    Task UpdateGoalAsync(Goal goal);
    Task DeleteGoalAsync(int id);
    Task<bool> GoalExistsAsync(int id);
}
