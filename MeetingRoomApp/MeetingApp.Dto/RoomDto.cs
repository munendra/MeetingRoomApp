using System;

namespace MeetingApp.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
