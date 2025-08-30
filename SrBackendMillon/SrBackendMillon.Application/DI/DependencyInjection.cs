using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SrBackendMillon.Application.Abstractions;
using SrBackendMillon.Application.Services;

namespace SrBackendMillon.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IImageService, PropertyService>();
            return services;
        }
    }
}
