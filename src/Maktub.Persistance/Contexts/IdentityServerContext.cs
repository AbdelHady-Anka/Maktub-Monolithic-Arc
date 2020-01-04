using System.Reflection;
using IdentityServer4.EntityFramework.Options;
using Maktub.Domain.Entities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Maktub.Persistance.Contexts
{
    public class IdentityServerDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IdentityServerDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

            base.OnModelCreating(builder);
        }
    }
}