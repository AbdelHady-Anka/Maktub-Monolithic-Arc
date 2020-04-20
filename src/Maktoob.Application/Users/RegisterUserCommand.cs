using Maktoob.Application.Commands;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Maktoob.Domain.Entities;
using Maktoob.CrossCuttingConcerns.Result;
using System.ComponentModel.DataAnnotations;
using Maktoob.Domain.Services;

namespace Maktoob.Application.Users
{
    public class RegisterUserCommand : ICommand<MaktoobResult>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public class Handler : ICommandHandler<RegisterUserCommand, MaktoobResult>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<MaktoobResult> HandleAsync(RegisterUserCommand command)
            {
                var user = new User
                {
                    Email = command.Email,
                    Name = command.UserName
                };

                user.PasswordHash = _userService.PasswordHasher.Hash(command.Password);

                var result = await _userService.CreateAsync(user);

                return result;
            }
        }
    }
    
}
