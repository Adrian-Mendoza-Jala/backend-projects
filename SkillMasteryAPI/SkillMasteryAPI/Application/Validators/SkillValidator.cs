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
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(skill => skill.Description)
                .MaximumLength(500).WithMessage("Description cannot be more than 500 characters.");

        }
    }
}
