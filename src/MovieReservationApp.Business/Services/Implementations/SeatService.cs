using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Business.Dtos.SeatDtos;
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
	public class SeatService : ISeatService
	{
		private readonly ISeatRepository repo;
		private readonly IMapper mapper;

		public SeatService( ISeatRepository repo, IMapper mapper)
        {
			this.repo = repo;
			this.mapper = mapper;
		}
        public async Task CreateAsync(SeatCreateDto dTO)
		{
			Seat res = mapper.Map<Seat>(dTO);
			res.CreatedAt = DateTime.Now;
			res.ModifiedAt = DateTime.Now;
			await repo.CreateAsync(res);
			await repo.CommitAsync();
		}

		public async Task DeleteAsync(int id)
		{
			if (id < 1) throw new InvalidIdException("Id is not valid");
			Seat res = await repo.GetByIdAsync(id);
			if (res == null) throw new EntityNotFoundException(" Seat not found!");
			repo.Delete(res);
			await repo.CommitAsync();
		}

		public async Task<ICollection<SeatGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Seat, bool>>? expression = null, params string[] includes)
		{
			var query = repo.GetByExpression(AsNoTracking, expression, includes);
			var datas = await query.ToListAsync();

			return mapper.Map<ICollection<SeatGetDto>>(datas);
		}

		public async Task<SeatGetDto> GetByIdAsync(int id)
		{
			if (id < 1) throw new InvalidIdException("Id is not valid");
			Seat res = await repo.GetByIdAsync(id);
			if (res == null) throw new EntityNotFoundException(" Seat not found!");
			SeatGetDto dto = mapper.Map<SeatGetDto>(res);
			return dto;
		}

		public async Task<SeatGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Seat, bool>>? expression = null, params string[] includes)
		{
			Seat? res = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
			if (res == null) throw new EntityNotFoundException("Seat  not found");
			return mapper.Map<SeatGetDto>(res);
		}

		public async Task UpdateAsync(int id, SeatUpdateDto dTO)
		{
			if (id < 1) throw new InvalidIdException("Id is not valid");
			Seat res = await repo.GetByIdAsync(id);
			if (res == null) throw new EntityNotFoundException(" Seat not found!");
			mapper.Map(dTO, res);
			res.ModifiedAt = DateTime.Now;
			await repo.CommitAsync();
		}
	}
}
