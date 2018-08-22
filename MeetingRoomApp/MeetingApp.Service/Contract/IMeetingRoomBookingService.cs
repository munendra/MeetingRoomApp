using MeetingApp.Dto;
using System.Threading.Tasks;

namespace MeetingApp.Service.Contract
{
    public interface IMeetingRoomBookingService
    {
        Task Booking(BookingDto booking);
    }
}
