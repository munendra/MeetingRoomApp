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

        public decimal Price { get; set; }

        public int SeatingCapacity { get; set; }

        public bool IsBooked { get; set; }

        public virtual IEnumerable<RoomFacility> Facilities { get; set; }
    
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
