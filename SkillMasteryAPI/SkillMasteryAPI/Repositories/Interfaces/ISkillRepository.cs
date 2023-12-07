using SkillMasteryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int id);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Skill skill);
        bool SkillExists(int id);
        Task<IEnumerable<Skill>> GetPaginatedSkillsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
    }
}
