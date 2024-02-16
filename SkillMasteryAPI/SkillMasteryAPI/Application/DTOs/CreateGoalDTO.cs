using System.ComponentModel.DataAnnotations;

namespace SkillMasteryAPI.Application.DTOs;

public class CreateGoalDTO
{
    [Required]
    public int SkillId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    public DateTime? Deadline { get; set; }
}

