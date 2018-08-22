using AutoMapper;
using MeetingApp.Domain.Entities;
using MeetingApp.Dto;

namespace MeetingApp.Mapper
{
    public class BookingMapper:Profile
    {
        public BookingMapper()
        {
            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDateTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndDateTime)).ReverseMap();

        }
    }
}
