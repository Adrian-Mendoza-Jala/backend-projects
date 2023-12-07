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

        public async Task UpdateSkillAsync(Skill skill)
        {
            await _skillRepository.UpdateSkillAsync(skill);
        }

        public async Task DeleteSkillAsync(int id)
        {
            var skill = await GetSkillByIdAsync(id);
            if (skill != null)
            {
                await _skillRepository.DeleteSkillAsync(skill);
            }
        }

        public bool SkillExists(int id)
        {
            return _skillRepository.SkillExists(id);
        }

        public async Task<IEnumerable<Skill>> GetPaginatedSkillsAsync(int pageNumber, int pageSize)
        {
            return await _skillRepository.GetPaginatedSkillsAsync(pageNumber, pageSize);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _skillRepository.GetTotalCountAsync();
        }
    }
}
