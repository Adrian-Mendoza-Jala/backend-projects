using SkillMasteryAPI.Models;
using SkillMasteryAPI.Services.Interfaces;
using SkillMasteryAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllSkillsAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(int id)
        {
            return await _skillRepository.GetSkillByIdAsync(id);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _skillRepository.AddSkillAsync(skill);
        }
    }
}
