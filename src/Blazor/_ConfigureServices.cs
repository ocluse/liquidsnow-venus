using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Blazor.Services;
using Ocluse.LiquidSnow.Venus.Blazor.Services.Internal;

namespace Ocluse.LiquidSnow.Venus.Blazor
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddVenusComponents(this IServiceCollection services)
        {
            return services.AddVenusComponents<VenusResolver>();
        }

        public static IServiceCollection AddVenusComponents<T>(this IServiceCollection services) where T : class, IVenusResolver
        {
            services.AddSingleton<IDialogService, DialogService>();
            return services.AddSingleton<IVenusResolver, T>();
        }
    }
}
