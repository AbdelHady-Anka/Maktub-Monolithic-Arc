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
    public class Repository<T> : IRepository<T>
        where T : AggregateRoot<Guid>
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync<T>(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Remove<T>(entity);
            return Task.CompletedTask;
        }

        public async Task<IList<T>> GetAsync(Specification<T> specification)
        {
            var result = await _dbContext.Set<T>().Where(specification.ToExpression()).ToListAsync().ConfigureAwait(true);

            return result;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Update<T>(entity);
            return Task.CompletedTask;
        }
    }
}
