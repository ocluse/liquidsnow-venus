using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Blazor.Services;
using Ocluse.LiquidSnow.Venus.Blazor.Services.Internal;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus.Blazor
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddVenusComponents(this IServiceCollection services)
        {
            return services
                .AddComponentServices()
                .AddVenusValues();
        }

        public static IServiceCollection AddVenusComponents<T>(this IServiceCollection services) where T : class, IVenusResolver
        {
            
            return services
                .AddComponentServices()
                .AddVenusValues<T>();
        }

        private static IServiceCollection AddComponentServices(this IServiceCollection services)
        {
            return services.AddSingleton<IDialogService, DialogService>();
        }
    }
}
