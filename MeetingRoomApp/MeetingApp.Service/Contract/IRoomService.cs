using MeetingApp.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Service.Contract
{
    public  interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAll();

        Task<bool> CheckRoomAvailability(CheckBookingDto checkBooking);
    }
}
