using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;

namespace SkillMasteryAPI.Application.Services;

public class GoalService : IGoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<IEnumerable<Goal>> GetAllGoalsAsync()
    {
        return await _goalRepository.GetAllGoalsAsync();
    }

    public async Task<Goal> GetGoalByIdAsync(int id)
    {
        return await _goalRepository.GetGoalByIdAsync(id);
    }

    public async Task<Goal> AddGoalAsync(Goal goal)
    {
        await _goalRepository.AddGoalAsync(goal);
        return goal;
    }

    public async Task<Goal> UpdateGoalAsync(int id, Goal goal)
    {
        var existingGoal = await _goalRepository.GetGoalByIdAsync(id);
        if (existingGoal == null)
        {
            return null;
        }

        existingGoal.Description = goal.Description;
        existingGoal.Deadline = goal.Deadline;
        existingGoal.Status = goal.Status;

        await _goalRepository.UpdateGoalAsync(existingGoal);
        return existingGoal;
    }

    public async Task<bool> DeleteGoalAsync(int id)
    {
        var existingGoal = await _goalRepository.GetGoalByIdAsync(id);
        if (existingGoal == null)
        {
            return false;
        }
        await _goalRepository.DeleteGoalAsync(id);
        return true;
    }
}