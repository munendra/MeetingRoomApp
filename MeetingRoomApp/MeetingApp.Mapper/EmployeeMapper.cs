using AutoMapper;
using MeetingApp.Domain.Entities;
using MeetingApp.Dto;

namespace MeetingApp.Mapper
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.EmployeeName)).ReverseMap();

        }
    }
}
