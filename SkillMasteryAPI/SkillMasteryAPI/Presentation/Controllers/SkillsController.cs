using Microsoft.AspNetCore.Mvc;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMasteryAPI.Presentation.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
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
        if (skills == null)
        {
            return NotFound();
        }
        return Ok(skills);
    }

    [HttpPost]
    public async Task<ActionResult<Skill>> PostSkill([FromBody] Skill skill)
    {
        if (skill == null)
        {
            return BadRequest("Skill data is null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
        return Ok(skill);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutSkill(int id, Skill skill)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var existingSkill = await _skillService.GetSkillByIdAsync(id);
            if (existingSkill == null)
            {
                return NotFound();
            }

            existingSkill.Name = skill.Name;
            existingSkill.Description = skill.Description;

            await _skillService.UpdateSkillAsync(existingSkill);

            return Ok(existingSkill);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the skill.");
        }

        return NoContent();
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
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

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
