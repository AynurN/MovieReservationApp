using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.ShowTimeDtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task CreateAsync(ShowTimeCreateDto dTO);
        Task UpdateAsync(int id, ShowTimeUpdateDto dTO);
        Task DeleteAsync(int id);
        Task<ICollection<ShowTimeGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
        Task<ShowTimeGetDto> GetByIdAsync(int id);

        Task<ShowTimeGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
    }
}
