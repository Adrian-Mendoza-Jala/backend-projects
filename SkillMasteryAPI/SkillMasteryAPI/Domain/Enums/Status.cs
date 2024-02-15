using System.ComponentModel;

namespace SkillMasteryAPI.Domain.Enums;

public enum Status
{
    [Description("Not Started")]
    NotStarted,

    [Description("In Progress")]
    InProgress,

    [Description("Completed")]
    Completed,

    [Description("On Hold")]
    OnHold,

    [Description("Pending")]
    Pending,

    [Description("Archived")]
    Archived,

    [Description("Aborted")]
    Aborted,

    [Description("Deferred")]
    Deferred,

    [Description("Rejected")]
    Rejected,

    [Description("Failed")]
    Failed
}
