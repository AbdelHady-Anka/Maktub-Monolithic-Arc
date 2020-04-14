using Maktoob.Application.Commands;
using Maktoob.CrossCuttingConcerns.Error;
using Maktoob.CrossCuttingConcerns.Result;
using Maktoob.Domain.Entities;
using Maktoob.Domain.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Maktoob.Application.Users
{
    public class SignInUserCommand : ICommand<MaktoobResult>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;

        public class Handler : ICommandHandler<SignInUserCommand, MaktoobResult>
        {
            private readonly SignInManager<User> _signInManager;
            private readonly IJsonWebTokenCoder _jsonWebTokenCoder;
            private readonly ErrorDescriber _errorDescriber;

            public Handler(SignInManager<User> signInManager, IJsonWebTokenCoder jsonWebTokenCoder, ErrorDescriber errorDescriber)
            {
                _signInManager = signInManager;
                _jsonWebTokenCoder = jsonWebTokenCoder;
                _errorDescriber = errorDescriber;
            }

            public async Task<MaktoobResult> HandleAsync(SignInUserCommand command)
            {

                var user = await _signInManager.UserManager.FindByNameAsync(command.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, command.Password, command.RememberMe, true);

                    if (result.Succeeded)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, command.UserName)
                        };

                        var token = _jsonWebTokenCoder.Encode(claims);

                        return MaktoobResult<string>.Success(token);
                    }
                    else
                    {
                        return MaktoobResult.Failed(new MaktoobError { Code = "SignInFailur", Description = "SignInFailur" });
                    }
                }
                return MaktoobResult.Failed();
            }
        }
    }
}
