using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.SeatDtos
{
	public record SeatGetDto(int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted,string TheaterName, string SeatNumber);
	
}
