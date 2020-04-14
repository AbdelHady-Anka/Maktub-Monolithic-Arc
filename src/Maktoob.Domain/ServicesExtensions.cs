using Maktoob.CrossCuttingConcerns.Normalizers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maktoob.Domain
{
    public static class ServicesExtensions
    {
        public static void  AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IKeyNormalizer, NameNormalizer>();
        }
    }
}
