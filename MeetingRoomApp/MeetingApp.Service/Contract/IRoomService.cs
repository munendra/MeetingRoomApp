using MeetingApp.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Service.Contract
{
    public  interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAll();

        Task<bool> CheckRoomAvailability(CheckBookingDto checkBooking);

        Task<IEnumerable<RoomDto>> GetAvailableRoom(DateTime startDate);

        Task<IEnumerable<RoomDto>> GetAll(int? seatingCapacity, IEnumerable<Dictionary<string, string>> filters = null);
    }
}
