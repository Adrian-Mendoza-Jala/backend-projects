using AutoMapper;
using SkillMasteryAPI.Application.DTOs;
using SkillMasteryAPI.Domain.Entities;
using System.ComponentModel;
using System.Reflection;

namespace SkillMasteryAPI.Application.Mappers;

public class GoalsProfile : Profile
{
    public GoalsProfile()
    {
        CreateMap<Goal, GoalResponseDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => GetEnumDescription(src.Status)))
            .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name));

        CreateMap<CreateGoalDTO, Goal>();
        CreateMap<UpdateGoalDTO, Goal>();
        CreateMap<Goal, GoalResponseDTO>();
    }

    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
}

