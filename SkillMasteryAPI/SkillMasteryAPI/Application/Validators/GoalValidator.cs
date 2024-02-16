using FluentValidation;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Application.Validators
{
    public class GoalValidator : AbstractValidator<Goal>
    {
        public GoalValidator()
        {
            RuleFor(g => g.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");

            RuleFor(g => g.Status)
                .IsInEnum().WithMessage("Status must be a valid enum value.");

            RuleFor(g => g.Deadline)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Deadline must be in the future.");
        }
    }
}