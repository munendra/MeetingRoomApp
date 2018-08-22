using MeetingApp.Dto;
using System;
using System.Collections.Generic;

namespace MeetingApp.Logic.Contract
{
    public interface IBookingValidation
    {
        void CheckRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime);
    }
}
