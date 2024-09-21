using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.TheaterDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Interfaces;
using MovieReservationApp.Core.Entities;
using MovieReservationApp.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Implementations
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository repo;
        private readonly IMapper mapper;

        public TheaterService(ITheaterRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(TheaterCreateDto dTO)
        {

            Theater theater = mapper.Map<Theater>(dTO);
            theater.CreatedAt = DateTime.Now;
            theater.ModifiedAt = DateTime.Now;
            await repo.CreateAsync(theater);
            await repo.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            Theater theater = await repo.GetByIdAsync(id);
            if (theater == null) throw new EntityNotFoundException("Theater not found!");
            repo.Delete(theater);
            await repo.CommitAsync();
        }

        public async Task<ICollection<TheaterGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            var query = repo.GetByExpression(AsNoTracking, expression, includes);
            var datas = await query.ToListAsync();

            return mapper.Map<ICollection<TheaterGetDto>>(datas);
        }

        public async Task<TheaterGetDto> GetByIdAsync(int id)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            Theater theater = await repo.GetByIdAsync(id);
            if (theater == null) throw new EntityNotFoundException("Theater not found!");
            return mapper.Map<TheaterGetDto>(theater);
        }

        public async Task<TheaterGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            Theater? theater = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
            if (theater == null) throw new EntityNotFoundException("Theater not found");
            return mapper.Map<TheaterGetDto>(theater);
        }

        public async Task UpdateAsync(int id, TheaterUpdateDto dTO)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            Theater theater = await repo.GetByIdAsync(id);
            if (theater == null) throw new EntityNotFoundException("Theater not found!");
            mapper.Map(dTO, theater);
            await repo.CommitAsync();
        }
    }
}
