﻿using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Data;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;

namespace SkillMasteryAPI.Infrastructure.Repositories.Implementations;

public class GoalRepository : IGoalRepository
{
    private readonly DataContext _context;

    public GoalRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Goal>> GetAllGoalsAsync()
    {
        return await _context.Goals.ToListAsync();
    }

    public async Task<Goal> GetGoalByIdAsync(int id)
    {
        return await _context.Goals.FindAsync(id);
    }

    public async Task AddGoalAsync(Goal goal)
    {
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGoalAsync(Goal goal)
    {
        _context.Entry(goal).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGoalAsync(int id)
    {
        var goal = await GetGoalByIdAsync(id);
        if (goal != null)
        {
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> GoalExistsAsync(int id)
    {
        return await _context.Goals.AnyAsync(g => g.Id == id);
    }
}
