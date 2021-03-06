﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("Booking")]
    public class Booking:IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        
        public Guid RoomId { get; set; }
      
        public Guid EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


    }
}
