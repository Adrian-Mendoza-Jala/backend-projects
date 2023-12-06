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
    }
}
