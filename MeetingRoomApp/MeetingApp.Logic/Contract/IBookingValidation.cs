using MeetingApp.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public interface IBookingValidation
    {
        bool IsRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime);
    }
}
