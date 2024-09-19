using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using MovieReservationApp.Business.Dtos;
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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository repo;
        private readonly IMapper mapper;

        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(MovieCreateDto dTO)
        {
            Movie movie = mapper.Map<Movie>(dTO);
            movie.CreatedAt = DateTime.Now;
            movie.ModifiedAt = DateTime.Now;
            await repo.CreateAsync(movie);
            await repo.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            Movie movie = await repo.GetByIdAsync(id);
            if (movie == null) throw new EntityNotFoundException("Movie not found!");
            repo.Delete(movie);
            await repo.CommitAsync();
        }

        public async Task<ICollection<MovieGetDto>> GetByExpessionAsync(bool AsNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var query = repo.GetByExpression(AsNoTracking, expression, includes);
            var datas = await query.ToListAsync();

            return mapper.Map<ICollection<MovieGetDto>>(datas);
        }

        public async Task<MovieGetDto> GetByIdAsync(int id)
        {

            if (id < 1) throw new InvalidIdException("Id is not valid");
            Movie movie = await repo.GetByIdAsync(id);
            if (movie == null) throw new EntityNotFoundException("Movie not found!");
            MovieGetDto dto = mapper.Map<MovieGetDto>(movie);
            return dto;
        }

        public async Task<MovieGetDto> GetOneByExpressionAsync(bool AsNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            Movie? movie = repo.GetByExpression(AsNoTracking, expression, includes).FirstOrDefault();
            if (movie == null) throw new EntityNotFoundException("Movie not found");
            return mapper.Map<MovieGetDto>(movie);
        }
            public async Task UpdateAsync(int id, MovieUpdateDto dTO)
            {
            if (id < 1) throw new InvalidIdException("Id is not valid");
            Movie movie = await repo.GetByIdAsync(id);
            if (movie == null) throw new EntityNotFoundException("Movie not found!");
            mapper.Map(dTO, movie);
            movie.ModifiedAt = DateTime.Now;
            await repo.CommitAsync();
        }
        }
    } 
