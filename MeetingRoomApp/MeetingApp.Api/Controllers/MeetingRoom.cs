using MeetingApp.Dto;
using MeetingApp.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetingApp.Api.Controllers
{

    [Route("api/v1/meeting-room")]
    public class MeetingRoom : Controller
    {
        private readonly IMeetingRoomBookingService _meetingRoomBookingService;
        private readonly IRoomService _roomService;
        public MeetingRoom(IMeetingRoomBookingService meetingRoomBookingService,
            IRoomService roomService)
        {
            _roomService = roomService;
            _meetingRoomBookingService = meetingRoomBookingService;
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody]BookingDto booking)
        {
            await _meetingRoomBookingService.Booking(booking);
            return Ok(booking);
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var rooms = await _roomService.GetAll();
            return Ok(rooms);
        }
    }
}