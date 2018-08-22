using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingApp.Logic.Implementation
{
    public class BookingValidation : IBookingValidation
    {
        public bool IsRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime)
        {
            return bookings.Any(booking => booking.EndDateTime < startDate);
        }
    }
}
