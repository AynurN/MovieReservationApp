using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.TheaterDtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
    public interface ITheaterService
    {
        Task CreateAsync(TheaterCreateDto dTO);
        Task UpdateAsync(int id, TheaterUpdateDto dTO);
        Task DeleteAsync(int id);
        Task<ICollection<TheaterGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
        Task<TheaterGetDto> GetByIdAsync(int id);

        Task<TheaterGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
    }
}

