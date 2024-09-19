using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task CreateAsync(MovieCreateDto dTO);
        Task UpdateAsync(int id, MovieUpdateDto dTO);
        Task DeleteAsync(int id);
        Task<ICollection<MovieGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
        Task<MovieGetDto> GetByIdAsync(int id);

        Task<MovieGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
    }
}
