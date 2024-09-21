using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.ShowTimeDtos
{
    public record ShowTimeGetDto(DateTime StartTime, DateTime EndTime, string MovieTitle, string TheaterName, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
    
}
