using Microsoft.AspNetCore.Mvc;
using SkillMasteryAPI.Models;
using SkillMasteryAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            await _skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkill), new { id = skill.Id }, skill);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return skill;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            try
            {
                await _skillService.UpdateSkillAsync(skill);
            }
            catch
            {
                if (!_skillService.SkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Message = $"Skill with ID {id} updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (!_skillService.SkillExists(id))
            {
                return NotFound();
            }

            await _skillService.DeleteSkillAsync(id);
            return Ok(new { Message = $"Skill with ID {id} was deleted." });
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetPaginatedSkills(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Invalid page number or page size.");
            }

            var skills = await _skillService.GetPaginatedSkillsAsync(pageNumber, pageSize);

            var totalCount = await _skillService.GetTotalCountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var response = new
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                Skills = skills
            };

            return Ok(response);
        }
    }
}
