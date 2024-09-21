using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.ReservationDtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
    public interface IReservationService 
    {
        Task CreateAsync(CreateReservationDto dTO);
        Task UpdateAsync(int id, UpdateReservationDto dTO);
        Task DeleteAsync(int id);
        Task<ICollection<GetReservationDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes);
        Task<GetReservationDto> GetByIdAsync(int id);

        Task<GetReservationDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes);
    }
}
