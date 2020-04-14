using Maktoob.Domain.Entities;
using Maktoob.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Maktoob.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
