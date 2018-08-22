using MeetingApp.Dto;
using System.Threading.Tasks;

namespace MeetingApp.Service.Contract
{
    public interface IRoomBookingService
    {
        Task Booking(BookingDto booking);
    }
}
