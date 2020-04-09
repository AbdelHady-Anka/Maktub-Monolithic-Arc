using maktoob.Domain.Entities;
using maktoob.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace maktoob.Domain.Services
{
    public interface ICrudService<T>
        where T : AggregateRoot<Guid>
    {
        Task<IList<T>> GetAsync(Specification<T> specification);
        T GetByIdAsync(Guid guid);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
