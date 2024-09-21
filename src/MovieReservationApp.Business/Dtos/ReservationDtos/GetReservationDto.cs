using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.ReservationDtos
{
    public record GetReservationDto(int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted, DateTime  ReservationDate, string UserUserName, DateTime ShowTimeStartTime, DateTime ShowTimeEndTime);

}
