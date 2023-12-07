using SkillMasteryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int id);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(int id);
        bool SkillExists(int id);
        Task<IEnumerable<Skill>> GetPaginatedSkillsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
    }
}
