using ASPNetCoreAPISample.Models;
using ASPNetCoreAPISample.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(c => c.Rate / 100.0m))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(c => Link.To(nameof(Controllers.RoomsController.GetRoomByIdAsync), new { roomId = c.Id })));
        }
    }
}
