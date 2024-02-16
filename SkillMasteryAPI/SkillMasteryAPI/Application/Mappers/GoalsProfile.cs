using AutoMapper;
using SkillMasteryAPI.Application.DTOs;
using SkillMasteryAPI.Domain.Entities;
using SkillMasteryAPI.Domain.Enums;


namespace SkillMasteryAPI.Application.Mappers;

public class GoalsProfile : Profile
{
    public GoalsProfile()
    {
        CreateMap<Goal, GoalResponseDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDescription()))
            .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name));

        CreateMap<CreateGoalDTO, Goal>();
        CreateMap<UpdateGoalDTO, Goal>()
            .ForMember(dest => dest.SkillId, opt => opt.Condition(src => src.SkillId.HasValue));
    }
}

