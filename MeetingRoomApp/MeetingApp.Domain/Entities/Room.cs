using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("Room")]
    public class Room : IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Fees { get; set; }

        public int SeatingCapacity { get; set; }

        public bool IsBooked { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
