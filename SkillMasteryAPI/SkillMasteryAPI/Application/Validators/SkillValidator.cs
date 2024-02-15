using FluentValidation;
using SkillMasteryAPI.Domain.Entities;

namespace SkillMasteryAPI.Application.Validators
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(skill => skill.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 255).WithMessage("Name must be between 2 and 255 characters.");

            RuleFor(skill => skill.Description)
                .MaximumLength(255).WithMessage("Description cannot be more than 255 characters.");

        }
    }
}
