using Maktoob.CrossCuttingConcerns.Security;
using Maktoob.Domain.Infrastructure;
using Maktoob.Infrastructure.JsonWebToken;
using Maktoob.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Maktoob.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services){
            services.AddScoped<IJsonWebTokenCoder, JsonWebTokenCoder>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}
