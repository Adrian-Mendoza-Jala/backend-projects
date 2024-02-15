using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;
using SkillMasteryAPI.Infrastructure.Data;

namespace SkillMasteryAPI.Infrastructure.Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _context;

        public SkillRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
        }

        public bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Skill>> GetPaginatedSkillsAsync(int pageNumber, int pageSize)
        {
            return await _context.Skills
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Skills.CountAsync();
        }
    }
}
