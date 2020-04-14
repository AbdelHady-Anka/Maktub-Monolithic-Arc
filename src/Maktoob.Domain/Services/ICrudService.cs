using Maktoob.CrossCuttingConcerns.Result;
using Maktoob.Domain.Entities;
using Maktoob.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maktoob.Domain.Services
{
    public interface ICrudService<T>
        where T : Entity<Guid>
    {
        Task<MaktoobResult> CreateAsync(T entity);
        Task<MaktoobResult> ReadAsync(Specification<T> spec);
        Task<MaktoobResult> UpdateAsync(T entity);
        Task<MaktoobResult> DeleteAsync(T entity);
    }
}
