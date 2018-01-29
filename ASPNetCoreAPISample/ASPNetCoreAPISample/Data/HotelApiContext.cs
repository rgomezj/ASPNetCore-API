using ASPNetCoreAPISample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Data
{
    public class HotelApiContext : DbContext
    {
        public HotelApiContext (DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<RoomEntity> Rooms { get; set; }

        public static void AddTestData(HotelApiContext dbContext)
        {
            dbContext.Rooms.Add(new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Premium Suite",
                Rate = 10119
            });

            dbContext.Rooms.Add(new RoomEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Standard",
                Rate = 23959
            });

            dbContext.SaveChanges();
        }
    }
}
