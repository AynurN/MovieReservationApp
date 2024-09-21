using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.ShowTimeDtos;
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
    public class ShowTimeService : IShowTimeService
    {
        private readonly IShowTimeRepository repo;
        private readonly IMapper mapper;

        public ShowTimeService( IShowTimeRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(ShowTimeCreateDto dTO)
        {

            ShowTime showTime  = mapper.Map<ShowTime>(dTO);
            showTime.CreatedAt = DateTime.Now;
            showTime.ModifiedAt = DateTime.Now;
            await repo.CreateAsync(showTime);
            await repo.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            ShowTime showTime = await repo.GetByIdAsync(id);
            if (showTime == null) throw new EntityNotFoundException("Show time not found!");
            repo.Delete(showTime);
            await repo.CommitAsync();
        }

        public async Task<ICollection<ShowTimeGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            var query = repo.GetByExpression(AsNoTracking, expression, includes);
            var datas = await query.ToListAsync();

            return mapper.Map<ICollection<ShowTimeGetDto>>(datas);
        }

        public async Task<ShowTimeGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            ShowTime showTime = await repo.GetByIdAsync(id);
            if (showTime == null) throw new EntityNotFoundException("Show time not found!");
            return mapper.Map<ShowTimeGetDto>(showTime);
        }

        public async Task<ShowTimeGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            ShowTime? showTime = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
            if (showTime == null) throw new EntityNotFoundException("Show time not found");
            return mapper.Map<ShowTimeGetDto>(showTime);
        }

        public async Task UpdateAsync(int id, ShowTimeUpdateDto dTO)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            ShowTime showTime = await repo.GetByIdAsync(id);
            if (showTime == null) throw new EntityNotFoundException("Show time not found!");
            mapper.Map(dTO, showTime);
            showTime.ModifiedAt = DateTime.Now;
            await repo.CommitAsync();
        }
    }
}
