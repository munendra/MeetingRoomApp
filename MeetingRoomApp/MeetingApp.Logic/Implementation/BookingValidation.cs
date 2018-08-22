using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingApp.Logic.Implementation
{
    public class BookingValidation : IBookingValidation
    {
        public void CheckRoomAvailable(IEnumerable<BookingDto> bookings, DateTime startDate, DateTime endDateTime)
        {
            var isRoomBooked = bookings.Any(booking => booking.EndDateTime < startDate);
            if (!isRoomBooked)
            {
                throw new Exception("Room not available");
            }
        }
    }
}
