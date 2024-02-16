using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillMasteryAPI.Application.DTOs;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Presentation.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class GoalsController : ControllerBase
{
    private readonly IGoalService _goalService;
    private readonly IMapper _mapper;

    public GoalsController(IGoalService goalService, IMapper mapper)
    {
        _goalService = goalService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
    {
        var goals = await _goalService.GetAllGoalsAsync();
        return Ok(_mapper.Map<IEnumerable<GoalResponseDTO>>(goals));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Goal>> GetGoal(int id)
    {
        var goal = await _goalService.GetGoalByIdAsync(id);
        if (goal == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<GoalResponseDTO>(goal));
    }

    [HttpPost]
    public async Task<ActionResult<Goal>> PostGoal([FromBody] CreateGoalDTO goalDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var goal = _mapper.Map<Goal>(goalDto);
        var createdGoal = await _goalService.AddGoalAsync(goal);
        var goalResponseDto = _mapper.Map<GoalResponseDTO>(createdGoal);

        return CreatedAtAction(nameof(GetGoal), new { id = goalResponseDto.Id }, goalResponseDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGoal(int id, [FromBody] UpdateGoalDTO goalDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var goalToUpdate = await _goalService.GetGoalByIdAsync(id);
        if (goalToUpdate == null)
        {
            return NotFound();
        }

        goalToUpdate = _mapper.Map<Goal>(goalDto);
        goalToUpdate.Id = id;

        try
        {
            await _goalService.UpdateGoalAsync(id, goalToUpdate);
            var goalResponseDto = _mapper.Map<GoalResponseDTO>(goalToUpdate);
            return Ok(goalResponseDto);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the goal.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGoal(int id)
    {
        var result = await _goalService.DeleteGoalAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return Ok(new { Message = $"Goal with ID {id} was deleted." });
    }
}