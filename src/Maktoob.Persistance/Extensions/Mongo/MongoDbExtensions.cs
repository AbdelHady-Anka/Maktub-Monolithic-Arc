using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;

namespace maktoob.Persistance.Extensions.Mongo
{
    public static class MongoDbExtensions
    {
        public static void AddMongoDb([NotNullAttribute] this IServiceCollection services, [NotNullAttribute] Action<MongoDbOptions> optionsAction)
        {
            var mongoOptions = new MongoDbOptions();
            optionsAction.Invoke(mongoOptions);
            services.Configure<MongoDbOptions>(options => { options = mongoOptions; });
            services.AddSingleton<IMongoClient>(sp =>
            {
                var mongoClient = new MongoClient(mongoOptions.ConnectionString);
                mongoClient.Settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
                return mongoClient;
            });
            services.AddScoped<IMongoDatabase>(serviceProvider =>
            {
                var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
                return mongoClient.GetDatabase(mongoOptions.DatabaseName);
            });
            RegisterConventions();
        }
        private static void RegisterConventions()
        {
            ConventionRegistry.Register("MaktibConvention", new MongoConvention(), _ => true);
        }
    }
}
