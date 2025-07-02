using Microsoft.Extensions.DependencyInjection;
using ReecsPortal.Application.AutoMapper;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Application.Services;

namespace ReecsPortal.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);


            services.AddScoped<IGeneratorService, GeneratorService>();


            return services;
        }
    }
}
