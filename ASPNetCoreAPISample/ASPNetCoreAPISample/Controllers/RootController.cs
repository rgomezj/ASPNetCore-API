using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNetCoreAPISample.Models;

namespace ASPNetCoreAPISample.Controllers
{
    [Route("/")]
    [ApiVersion("1.0")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                //HRef = Link.LinkTo(nameof(GetRoot), null),
                Rooms = Link.LinkTo(nameof(RoomsController.GetRooms), null)
            };

            return Ok(response);
        }
    }
}
