using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Service.Contract;
using System.Threading.Tasks;

namespace MeetingApp.Service.Implementation
{
    public class MeetingRoomBookingService : IMeetingRoomBookingService
    {
        private readonly IMeetingRoomBookingLogic _meetingRoomBookingLogic;

        public MeetingRoomBookingService(IMeetingRoomBookingLogic meetingRoomBookingLogic)
        {
            _meetingRoomBookingLogic = meetingRoomBookingLogic;
        }
        public async Task Booking(BookingDto booking)
        {
            await _meetingRoomBookingLogic.Booking(booking);
        }
    }
}
