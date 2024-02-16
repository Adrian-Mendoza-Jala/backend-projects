using System.ComponentModel.DataAnnotations;

namespace SkillMasteryAPI.Domain.Entities;

public class Skill : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    // public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();
}

