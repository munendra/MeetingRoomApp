using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingApp.Dto
{
   public class RoomFacilityDto
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
