﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Models
{
    public class HotelOptions
    {
        public int DayStartsOnHour { get; set; }

        public int MinimumStayHours { get; set; }

        public int UtcOffsetHours { get; set; }

        public int MaxAdvanceBookingDays { get; set; }
    }
}
