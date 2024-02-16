using SkillMasteryAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillMasteryAPI.Application.DTOs;

public class UpdateGoalDTO
{
    [Required]
    public int? SkillId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    public DateTime? Deadline { get; set; }

    public Status? Status { get; set; }
}

