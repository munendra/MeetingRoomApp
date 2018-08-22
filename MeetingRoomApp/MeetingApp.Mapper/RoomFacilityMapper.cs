using AutoMapper;
using MeetingApp.Domain.Entities;
using MeetingApp.Dto;

namespace MeetingApp.Mapper
{
    public class RoomFacilityMapper : Profile
    {
        public RoomFacilityMapper()
        {
            CreateMap<RoomFacilityDto, RoomFacility>().ReverseMap();
            
        }
    }
}
