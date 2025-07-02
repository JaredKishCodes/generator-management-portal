using ReecsPortal.Application;
using ReecsPortal.Infrastructure;

namespace ReecsPortal.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI(configuration);

            return services;
        }
    }
}
