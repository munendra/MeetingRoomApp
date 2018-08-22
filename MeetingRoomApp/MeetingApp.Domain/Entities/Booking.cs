using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Room")]
        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public byte[] RowVersion { get; set; }


    }
}
