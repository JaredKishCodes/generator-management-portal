using Microsoft.Extensions.DependencyInjection;

namespace ReecsPortal.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));


            return services;
        }
    }
}
