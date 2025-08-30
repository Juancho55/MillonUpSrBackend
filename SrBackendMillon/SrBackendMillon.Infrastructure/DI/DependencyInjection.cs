using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SrBackendMillon.Infrastructure.Config;
using SrBackendMillon.Infrastructure.Persistence;
using SrBackendMillon.Infrastructure.Repositories;

namespace SrBackendMillon.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("MongoSettings").Get<MongoSettings>();

            if (mongoSettings == null)
            {
                throw new InvalidOperationException("MongoSettings cannot be null. Please ensure the configuration is properly set.");
            }

            services.AddSingleton(mongoSettings);

            services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(mongoSettings.ConnectionString);
            });
            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(mongoSettings.DatabaseName);
            });
            services.AddSingleton<IMongoCollectionFactory, MongoCollectionFactory>();

            services.AddScoped<IPropertyRepository, MongoPropertyRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}
