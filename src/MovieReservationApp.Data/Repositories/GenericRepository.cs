using Microsoft.EntityFrameworkCore;
using MovieReservationApp.Core.Entities;
using MovieReservationApp.Core.IRepositories;
using MovieReservationApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DbSet<TEntity> Table => context.Set<TEntity>();

        public async Task<int> CommitAsync() => await context.SaveChangesAsync();

        public async Task CreateAsync(TEntity entity) => await Table.AddAsync(entity);


        public async void Delete(TEntity entity) => Table.Remove(entity);


        public IQueryable<TEntity> GetByExpression(bool AsNoTracking = false, Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var i in includes)
                {
                    query = query.Include(i);

                }
            }
            if (AsNoTracking) query = query.AsNoTracking();
            return expression is not null ? query.Where(expression) : query;
        }

        public async Task<TEntity> GetByIdAsync(int id) => await Table.FirstOrDefaultAsync(t => t.Id == id);

    }
}
