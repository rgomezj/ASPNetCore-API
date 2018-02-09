using ASPNetCoreAPISample.Models.Entities;
using ASPNetCoreAPISample.Services;
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

        public DbSet<BookingEntity> Bookings { get; set; }

        public static void AddTestData(HotelApiContext dbContext, IDateLogicService dateLogicService)
        {
            var premium = dbContext.Rooms.Add(new RoomEntity()
            {
                Id = Guid.Parse("5c8fbfee-e9e3-4bcc-bdee-643203a30ef9"),
                Name = "Premium Suite",
                Rate = 10119
            }).Entity;

            dbContext.Rooms.Add(new RoomEntity()
            {
                Id = Guid.Parse("c3b7ed37-e6a9-457c-b1c8-42cc7ba07095"),
                Name = "Standard",
                Rate = 23959
            });

            var today = DateTimeOffset.Now;
            var start = dateLogicService.AlignStartTime(today);
            var end = start.Add(dateLogicService.GetMinimumStay());

            dbContext.Bookings.Add(new BookingEntity
            {
                Id = Guid.Parse("2eac8dea-2749-42b3-9d21-8eb2fc0fd6bd"),
                Room = premium,
                CreatedAt = DateTimeOffset.UtcNow,
                StartAt = start,
                EndAt = end,
                Total = premium.Rate,
            });

            dbContext.SaveChanges();
        }
    }
}
