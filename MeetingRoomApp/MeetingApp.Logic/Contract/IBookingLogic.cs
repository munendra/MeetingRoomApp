using MeetingApp.Dto;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public  interface IBookingLogic
    {
        Task Booking(BookingDto booking);
        
    }
}
