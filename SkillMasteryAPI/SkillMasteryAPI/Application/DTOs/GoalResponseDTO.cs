using SkillMasteryAPI.Domain.Enums;

namespace SkillMasteryAPI.Application.DTOs;

public class GoalResponseDTO
{
    public int Id { get; set; }
    public int SkillId { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Status { get; set; }
    // public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string SkillName { get; set; }
}

