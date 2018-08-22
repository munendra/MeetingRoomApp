using MeetingApp.Dto;
using MeetingApp.Logic.Implementation;
using MeetingApp.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Service.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomLogic _roomLogic;
        public RoomService(IRoomLogic roomLogic)
        {
            _roomLogic = roomLogic;
        }

        public async Task<IEnumerable<RoomDto>> GetAll()
        {
            return await _roomLogic.GetAll();
        }

        public async Task<bool> CheckRoomAvailability(CheckBookingDto checkBooking)
        {
           return await _roomLogic.CheckRoomAvailability(checkBooking);
        }
    }
}
