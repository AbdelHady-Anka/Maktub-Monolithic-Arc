using System.Threading.Tasks;
using Maktoob.Application.Commands;
using Maktoob.CrossCuttingConcerns.Result;
using Maktoob.Domain.Models;
using Maktoob.Domain.Services;

namespace Maktoob.Application.Users
{
    public class RefreshTokenCommand : ICommand<GResult<TokenModel>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public class Handler : ICommandHandler<RefreshTokenCommand, GResult<TokenModel>>
        {
            private readonly ISignInService _signInService;

            public Handler(ISignInService signInService)
            {
                _signInService = signInService;
            }

            public async Task<GResult<TokenModel>> HandleAsync(RefreshTokenCommand command)
            {
                var result = await _signInService.RefreshTokenAsync(command.Token, command.RefreshToken);

                return result;
            }
        }
    }
}
