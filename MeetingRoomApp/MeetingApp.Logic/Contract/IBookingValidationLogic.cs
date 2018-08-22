using MeetingApp.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public interface IBookingValidationLogic
    {
        bool IsRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime);
    }
}
