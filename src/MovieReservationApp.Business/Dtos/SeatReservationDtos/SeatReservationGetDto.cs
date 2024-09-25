using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.SeatReservationDtos
{
    public record SeatReservationGetDto(string SeatNumber, bool IsBooked,int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
    
}
