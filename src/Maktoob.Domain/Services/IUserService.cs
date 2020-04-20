using Maktoob.CrossCuttingConcerns.Result;
using Maktoob.CrossCuttingConcerns.Security;
using Maktoob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maktoob.Domain.Services
{
    public interface IUserService : ICrudService<User>
    {
        IPasswordHasher PasswordHasher { get; }
        Task<MaktoobResult> SignInAsync(string username, string password);
    }
}
