using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ocluse.LiquidSnow.Venus.Blazor.Services;
using Ocluse.LiquidSnow.Venus.Blazor.Services.Implementations;
using Ocluse.LiquidSnow.Venus.Services;
using System.Runtime.InteropServices;

namespace Ocluse.LiquidSnow.Venus.Blazor
{
    public static class ConfigureServices
    {
        public static VenusServiceBuilder AddComponents(this VenusServiceBuilder builder)
        {
            return builder.AddComponents<BlazorContainerStateResolver>();
        }

        public static VenusServiceBuilder AddComponents<T>(this VenusServiceBuilder builder)
            where T: class, IBlazorContainerStateResolver
        {
            builder.Services.RemoveAll(typeof(IDialogService));
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.RemoveAll(typeof(IBlazorContainerStateResolver));
            builder.Services.AddSingleton<IBlazorContainerStateResolver, T>();

            return builder;
        }

        public static VenusServiceBuilder AddVenusComponents(this IServiceCollection services)
        {
            return services.AddVenus()
                .AddComponents();
        }
    }
}
