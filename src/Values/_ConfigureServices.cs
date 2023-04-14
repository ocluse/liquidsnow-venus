using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddVenusValues(this IServiceCollection services)
        {
            return services.AddVenusValues<VenusResolver>();
        }

        public static IServiceCollection AddVenusValues<T>(this IServiceCollection services) where T : class, IVenusResolver
        {
            return services.AddSingleton<IVenusResolver, T>();
        }
    }
}
