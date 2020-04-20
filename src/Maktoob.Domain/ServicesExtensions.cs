using Maktoob.CrossCuttingConcerns.Error;
using Maktoob.CrossCuttingConcerns.Normalizers;
using Maktoob.Domain.Entities;
using Maktoob.Domain.Services;
using Maktoob.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maktoob.Domain
{
    public static class ServicesExtensions
    {
        public static void  AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IKeyNormalizer, NameNormalizer>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<MaktoobErrorDescriber>();
        }
    }
}
