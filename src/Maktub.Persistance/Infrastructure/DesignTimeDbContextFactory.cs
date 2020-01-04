using System.IO;
using IdentityServer4.EntityFramework.Options;
using Maktub.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Maktub.Persistance.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityServerDbContext>
    {
        public IdentityServerDbContext CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
            
            .SetBasePath(Path.GetFullPath("../Maktub.Presentation"))
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<IdentityServerDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            var operationalStoreOptions = Options.Create<OperationalStoreOptions>(new OperationalStoreOptions());
            return new IdentityServerDbContext(builder.Options, operationalStoreOptions);
        }
    }
}