using Maktoob.CrossCuttingConcerns.Result;
using System.Threading.Tasks;

namespace Maktoob.Domain.Validators
{
    public interface IValidator<TEntity> where TEntity : class, new()
    {
        Task<MaktoobResult> ValidateAsync(TEntity entity);
    }
}
