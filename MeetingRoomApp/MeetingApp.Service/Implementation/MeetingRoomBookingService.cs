using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Service.Contract;
using System.Threading.Tasks;

namespace MeetingApp.Service.Implementation
{
    public class MeetingRoomBookingService : IRoomBookingService
    {
        private readonly IBookingLogic _meetingRoomBookingLogic;

        public MeetingRoomBookingService(IBookingLogic meetingRoomBookingLogic)
        {
            _meetingRoomBookingLogic = meetingRoomBookingLogic;
        }
        public async Task Booking(BookingDto booking)
        {
            await _meetingRoomBookingLogic.Booking(booking);
        }
    }
}
