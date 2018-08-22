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
        public MeetingRoom(IMeetingRoomBookingService meetingRoomBookingService)
        {
            _meetingRoomBookingService = meetingRoomBookingService;
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody]BookingDto booking)
        {
            await _meetingRoomBookingService.Booking(booking);
            return Ok(booking);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}