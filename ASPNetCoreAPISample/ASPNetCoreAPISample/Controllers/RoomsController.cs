using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNetCoreAPISample.Data;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreAPISample.Models;

namespace ASPNetCoreAPISample.Controllers
{
    [Route("/[Controller]")]
    public class RoomsController : Controller
    {
        private readonly HotelApiContext _dataContext;

        
        public RoomsController(HotelApiContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            var rooms = _dataContext.Rooms.ToList();
            return Ok(rooms);
        }

        [HttpGet("{roomId}", Name = nameof(GetRoomByIdAsync))]
        public async Task<IActionResult> GetRoomByIdAsync(Guid roomId, CancellationToken ct)
        {
            var entity = await _dataContext.Rooms.SingleOrDefaultAsync(c => c.Id == roomId, ct);
            if (entity == null) return NotFound();

            var resource = new Room()
            {
                Href = Url.Link(nameof(GetRoomByIdAsync), new { roomId = roomId }),
                Name = entity.Name,
                Rate = entity.Rate / 100.0m
            };
            return Ok(resource);
        }
    }
}
