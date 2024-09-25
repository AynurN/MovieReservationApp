using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.SeatDtos
{
	public record SeatCreateDto(string SeatNumber, int TheaterId);
	
}
