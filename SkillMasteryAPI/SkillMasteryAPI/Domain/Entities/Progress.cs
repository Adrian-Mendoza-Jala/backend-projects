using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillMasteryAPI.Domain.Entities;

public class Progress : BaseEntity
{
    [Required]
    public int SkillId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Milestones { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [ForeignKey("SkillId")]
    public Skill Skill { get; set; }
}

