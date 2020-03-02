using System.IO;
using maktoob.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace maktoob.Persistance.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityMDbContext>
    {
        public IdentityMDbContext CreateDbContext(string[] args)
        {
            
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //.SetBasePath(Path.GetFullPath("../maktoob.SPA"))
            //.AddJsonFile("appsettings.json")
            //.Build();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<IdentityMDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=maktoob;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new IdentityMDbContext(builder.Options);
        }
    }
}