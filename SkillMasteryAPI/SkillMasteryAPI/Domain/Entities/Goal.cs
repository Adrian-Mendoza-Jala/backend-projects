﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SkillMasteryAPI.Domain.Enums;

namespace SkillMasteryAPI.Domain.Entities;

public class Goal : BaseEntity
{
    [Required]
    public int SkillId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }

    public DateTime Deadline { get; set; }

    [Required]
    [EnumDataType(typeof(Status))]
    public Status Status { get; set; }

    [ForeignKey("SkillId")]
    public Skill Skill { get; set; }
}

