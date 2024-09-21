using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.ReservationDtos;
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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository repo;
        private readonly IMapper mapper;

        public ReservationService(IReservationRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateReservationDto dTO)
        {
            Reservation res = mapper.Map<Reservation>(dTO);
            res.CreatedAt = DateTime.Now;
            res.ModifiedAt = DateTime.Now;
            await repo.CreateAsync(res);
            await repo.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            Reservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException("Reservation not found!");
            repo.Delete(res);
            await repo.CommitAsync();
        }

        public async Task<ICollection<GetReservationDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var query = repo.GetByExpression(AsNoTracking, expression, includes);
            var datas = await query.ToListAsync();

            return mapper.Map<ICollection<GetReservationDto>>(datas);
        }

        public async Task<GetReservationDto> GetByIdAsync(int id)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            Reservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException("Reservation not found!");
            GetReservationDto dto = mapper.Map<GetReservationDto>(res);
            return dto;
        }

        public async Task<GetReservationDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            Reservation? res = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
            if (res == null) throw new EntityNotFoundException("Reservation not found");
            return mapper.Map<GetReservationDto>(res);
        }

        public async Task UpdateAsync(int id, UpdateReservationDto dTO)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            Reservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException("Reservation not found!");
            mapper.Map(dTO, res);
            res.ModifiedAt = DateTime.Now;
            await repo.CommitAsync();
        }
    }
}
