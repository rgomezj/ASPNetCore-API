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
using ASPNetCoreAPISample.Services;

namespace ASPNetCoreAPISample.Controllers
{
    [Route("/[Controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetRoomsAsync))]
        public async Task<IActionResult> GetRoomsAsync(CancellationToken ct)
        {
            var rooms = await _service.GetRoomsAsync(ct);

            var collectionLink = Link.ToCollection(nameof(GetRoomsAsync));

            var collection = new Collection<Room>
            {
                Self = collectionLink,
                Value = rooms.ToArray()
            };

            return Ok(collection);
        }

        [HttpGet("{roomId}", Name = nameof(GetRoomByIdAsync))]
        public async Task<IActionResult> GetRoomByIdAsync(Guid roomId, CancellationToken ct)
        {
            var entity = await _service.GetRoomAsync(roomId, ct);
            if (entity == null) return NotFound();

            return Ok(entity);
        }
    }
}
