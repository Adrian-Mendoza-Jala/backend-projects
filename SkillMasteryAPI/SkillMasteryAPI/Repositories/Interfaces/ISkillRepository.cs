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
    }
}
