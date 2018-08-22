using AutoMapper;
using MeetingApp.Domain.Entities;
using MeetingApp.Dto;

namespace MeetingApp.Mapper
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
            
        }
    }
}
