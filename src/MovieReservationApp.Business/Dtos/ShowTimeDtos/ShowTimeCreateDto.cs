using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.ShowTimeDtos
{
    public record ShowTimeCreateDto(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId );
   
}
