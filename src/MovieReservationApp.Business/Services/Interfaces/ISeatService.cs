using MovieReservationApp.Business.Dtos.SeatDtos;
using MovieReservationApp.Business.Dtos.SeatReservationDtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
	public interface ISeatService
	{
		Task CreateAsync(SeatCreateDto dTO);
		Task UpdateAsync(int id, SeatUpdateDto dTO);
		Task DeleteAsync(int id);
		Task<ICollection<SeatGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Seat, bool>>? expression = null, params string[] includes);
		Task<SeatGetDto> GetByIdAsync(int id);

		Task<SeatGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Seat, bool>>? expression = null, params string[] includes);
	}
}
