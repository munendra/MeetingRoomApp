using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingApp.Domain.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string empId { get; set; }

        public string Fullname { get; set; }

        public byte[] Rowversion { get; set; }
    }
}
