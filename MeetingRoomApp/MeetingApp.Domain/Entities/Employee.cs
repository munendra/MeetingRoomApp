using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("Employee")]
    public class Employee :IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        public string EmpId { get; set; }

        public string Fullname { get; set; }
        [Timestamp]
        public byte[] Rowversion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
