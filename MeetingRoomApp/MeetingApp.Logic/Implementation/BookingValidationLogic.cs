using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingApp.Logic.Implementation
{
    public class BookingValidationLogic : IBookingValidationLogic
    {
        public bool IsRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime)
        {
            if (bookings.Count()==0)
            {
                return true;
            }
            return bookings.Any(booking => booking.EndDateTime < startDate);
        }
    }
}
