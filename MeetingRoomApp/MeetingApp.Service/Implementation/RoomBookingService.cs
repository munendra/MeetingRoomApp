using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Service.Contract;
using System;
using System.Threading.Tasks;

namespace MeetingApp.Service.Implementation
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly IBookingLogic _meetingRoomBookingLogic;

        public RoomBookingService(IBookingLogic meetingRoomBookingLogic)
        {
            _meetingRoomBookingLogic = meetingRoomBookingLogic;
        }
        public async Task Booking(BookingDto booking)
        {
            await _meetingRoomBookingLogic.Booking(booking);
        }


        public async Task<double> Expense(Guid? employeeId)
        {
            if (employeeId.HasValue && employeeId.Value != default(Guid))
            {
                return await _meetingRoomBookingLogic.Expense(employeeId.Value);
            }
            return await _meetingRoomBookingLogic.Expense();
        }
    }
}
