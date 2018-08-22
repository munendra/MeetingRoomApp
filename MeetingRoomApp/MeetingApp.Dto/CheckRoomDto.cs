using System;

namespace MeetingApp.Dto
{
    public  class CheckBookingDto
    {
        public Guid RoomId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
