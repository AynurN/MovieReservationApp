using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.TheaterDtos
{
    public record TheaterGetDto(string Name, string Location, int TotalSeats, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
    
}
