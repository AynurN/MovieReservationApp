using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.ReservationDtos
{
    public record CreateReservationDto(DateTime ReservationDate, int UserId, int ShowTimeId);
    
}
