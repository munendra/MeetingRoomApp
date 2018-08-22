using MeetingApp.Dto;
using MeetingApp.Logic.Implementation;
using MeetingApp.Service.Contract;
using System;
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

        public async Task<IEnumerable<RoomDto>> GetAvailableRoom(DateTime startDate)
        {
            return await _roomLogic.GetAvailableRoom(startDate);
        }


        public async Task<IEnumerable<RoomDto>> GetAll(int? seatingCapacity = 0, IEnumerable<Dictionary<string, string>> filters = null)
        {
           _roomLogic.  
        }
    }
}
