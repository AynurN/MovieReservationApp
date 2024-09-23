using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Business.Dtos.ReservationDtos;
using MovieReservationApp.Business.Dtos.SeatReservationDtos;
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
    public class SeatReservationService : ISeatReservationService
    {
        private readonly ISeatReservationRepository repo;
        private readonly IMapper mapper;

        public SeatReservationService(ISeatReservationRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(SeatReservationCreateDto dTO)
        {
            SeatReservation res = mapper.Map<SeatReservation>(dTO);
            res.CreatedAt = DateTime.Now;
            res.ModifiedAt = DateTime.Now;
            await repo.CreateAsync(res);
            await repo.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            SeatReservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException(" Seat reservation not found!");
            repo.Delete(res);
            await repo.CommitAsync();
        }

        public async Task<ICollection<SeatReservationGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            var query = repo.GetByExpression(AsNoTracking, expression, includes);
            var datas = await query.ToListAsync();

            return mapper.Map<ICollection<SeatReservationGetDto>>(datas);
        }

        public async Task<SeatReservationGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            SeatReservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException(" Seat reservation not found!");
            SeatReservationGetDto dto = mapper.Map<SeatReservationGetDto>(res);
            return dto;
        }

        public async Task<SeatReservationGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            SeatReservation? res = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
            if (res == null) throw new EntityNotFoundException("Seat Reservation not found");
            return mapper.Map<SeatReservationGetDto>(res);
        }

        public async Task UpdateAsync(int id, SeatReservationUpdateDto dTO)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            SeatReservation res = await repo.GetByIdAsync(id);
            if (res == null) throw new EntityNotFoundException(" Seat reservation not found!");
            mapper.Map(dTO, res);
            res.ModifiedAt = DateTime.Now;
            await repo.CommitAsync();
        }
    }
}
