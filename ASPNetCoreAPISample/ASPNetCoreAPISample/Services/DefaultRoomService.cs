using ASPNetCoreAPISample.Data;
using ASPNetCoreAPISample.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiContext _dataContext;

        public DefaultRoomService(HotelApiContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Room> GetRoomAsync(Guid id, CancellationToken ct)
        {
            var entity = await _dataContext.Rooms.SingleOrDefaultAsync(c => c.Id == id, ct);
            if (entity == null) return null;

            return Mapper.Map<Room>(entity);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync(CancellationToken ct)
        {
            var query = _dataContext.Rooms.ProjectTo<Room>();
            
            return await query.ToArrayAsync(ct);
        }
    }
}
