using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus.Razor
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddVenusRazor(this IServiceCollection services)
        {
            return services.AddLocalServices()
                .AddVenusValues();
        }

        public static IServiceCollection AddVenusRazor<T>(this IServiceCollection services) where T : class, IVenusResolver
        {
            return services.AddLocalServices()
                .AddVenusValues<T>();
        }

        public static IServiceCollection AddLocalServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
