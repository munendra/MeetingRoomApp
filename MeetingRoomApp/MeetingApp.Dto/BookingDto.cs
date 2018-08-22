using System;


namespace MeetingApp.Dto
{
   // [Validator(typeof(BookingValidator))]
    public class BookingDto
    {

        public string EmployeeName { get; set; }

        public string EmployeeId { get; set; }

        public Guid RoomId { get; set; }

        public double TotalAmount { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
