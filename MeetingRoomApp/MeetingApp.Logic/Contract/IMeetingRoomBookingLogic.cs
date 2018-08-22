using MeetingApp.Dto;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public  interface IMeetingRoomBookingLogic
    {
        Task Booking(BookingDto booking);
    }
}
