﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public enum BookingStatus
    {
        Reserved,
        Confirmed,
        Rejected,
        Cancelled,
        Completed
    }
}
