using MovieReservationApp.Business.Dtos.ReservationDtos;
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
    public interface ISeatReservationService
    {
        Task CreateAsync(SeatReservationCreateDto dTO);
        Task UpdateAsync(int id, SeatReservationUpdateDto dTO);
        Task DeleteAsync(int id);
        Task<ICollection<SeatReservationGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
        Task<SeatReservationGetDto> GetByIdAsync(int id);

        Task<SeatReservationGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
    }
}
