using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.SeatReservationDtos
{
    public record SeatReservationUpdateDto(int SeatId, bool IsBooked, int? ReservationId);
    
}
