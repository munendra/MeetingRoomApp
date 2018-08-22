using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
   
    [Route("api/v1/meeting-room")]
    public class MeetingRoom : Controller
    {
        [HttpPost]
        public IActionResult Book()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}