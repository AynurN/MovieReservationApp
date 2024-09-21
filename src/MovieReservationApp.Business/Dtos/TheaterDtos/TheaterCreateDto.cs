using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.TheaterDtos
{
    public record TheaterCreateDto(string Name, string Location, int TotalSeats);
   
}
