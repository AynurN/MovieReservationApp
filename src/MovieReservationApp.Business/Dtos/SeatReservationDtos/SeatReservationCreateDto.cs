﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.SeatReservationDtos
{
    public record SeatReservationCreateDto(string SeatNumber, bool IsBooked, int ReservationId);
   
}
