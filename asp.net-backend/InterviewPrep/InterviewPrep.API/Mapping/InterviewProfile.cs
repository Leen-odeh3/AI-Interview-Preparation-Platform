using AutoMapper;
using InterviewPrep.Core.DTOs.Interview;
using InterviewPrep.Core.Entities;

namespace InterviewPrep.API.Mapping;

public class InterviewProfile : Profile
{
    public InterviewProfile()
    {
        CreateMap<InterviewDTO, Interview>();
    }
}