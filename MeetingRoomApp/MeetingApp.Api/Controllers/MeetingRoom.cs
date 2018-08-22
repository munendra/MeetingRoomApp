using MeetingApp.Dto;
using MeetingApp.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeetingApp.Api.Controllers
{

    [Route("api/v1/meeting-room")]
    public class MeetingRoom : Controller
    {
        private readonly IRoomBookingService _roomBookingService;
        private readonly IRoomService _roomService;
        public MeetingRoom(IRoomBookingService meetingRoomBookingService,
            IRoomService roomService)
        {
            _roomService = roomService;
            _roomBookingService = meetingRoomBookingService;
        }

        [HttpPost]
        [Route("booking")]
        public async Task<IActionResult> Post([FromBody]BookingDto booking)
        {
            await _roomBookingService.Booking(booking);
            return Ok(booking);
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var rooms = await _roomService.GetAll();
            return Ok(rooms);
        }

        [HttpPost]
        [Route("availability")]
        public async Task<IActionResult> Availability([FromBody]CheckBookingDto checkRoom)
        {
            var isAvailability = await _roomService.CheckRoomAvailability(checkRoom);
            return Ok(isAvailability);
        }


        [HttpGet]
        [Route("available-rooms/{from?}")]
        public async Task<IActionResult> AvailableRooms(DateTime? from)
        {
            if (!from.HasValue)
            {
                from = DateTime.UtcNow;
            }
            var availableRooms = await _roomService.GetAvailableRoom(from.Value);
            return Ok(availableRooms);
        }
    }
}