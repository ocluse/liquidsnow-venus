using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Services.Implementations;

namespace Ocluse.LiquidSnow.Venus
{
    public static class ConfigureServices
    {
        public static VenusServiceBuilder AddVenus(this IServiceCollection services)
        {
            VenusServiceBuilder builder = new(services);
            return builder.AddResolver<VenusResolver>();
        }
    }
}
