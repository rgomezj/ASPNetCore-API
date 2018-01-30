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
                Id = Guid.Parse("5c8fbfee-e9e3-4bcc-bdee-643203a30ef9"),
                Name = "Premium Suite",
                Rate = 10119
            });

            dbContext.Rooms.Add(new RoomEntity()
            {
                Id = Guid.Parse("c3b7ed37-e6a9-457c-b1c8-42cc7ba07095"),
                Name = "Standard",
                Rate = 23959
            });

            dbContext.SaveChanges();
        }
    }
}
