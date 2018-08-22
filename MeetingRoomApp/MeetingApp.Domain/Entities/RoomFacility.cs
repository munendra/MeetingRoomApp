﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("RoomFacility")]
    public class RoomFacility:IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Room")]
        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        [Timestamp]

        public byte[] RowVersion { get; set; }
    }
}