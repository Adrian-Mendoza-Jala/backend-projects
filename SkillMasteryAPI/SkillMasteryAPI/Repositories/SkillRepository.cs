using SkillMasteryAPI.Data;
using SkillMasteryAPI.Models;
using SkillMasteryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Repositories
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
    }
}
