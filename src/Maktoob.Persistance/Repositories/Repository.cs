using Maktoob.Domain.Entities;
using Maktoob.Domain.Repositories;
using Maktoob.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktoob.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity<Guid>
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync<TEntity>(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbContext.Remove<TEntity>(entity);
            return Task.CompletedTask;
        }

        public async Task<IList<TEntity>> GetAsync(MultiResultSpec<TEntity> spec)
        {
            var result = await _dbContext.Set<TEntity>().Where(spec.ToExpression()).ToListAsync();

            return result;
        }

        public async Task<TEntity> GetAsync(SingleResultSpec<TEntity> spec)
        {
            var reslut = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(spec.ToExpression());

            return reslut;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);
            return Task.CompletedTask;
        }
    }
}
