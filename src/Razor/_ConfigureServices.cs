using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus.Razor
{
    public static class ConfigureServices
    {
        public static VenusServiceBuilder AddRazor(this VenusServiceBuilder builder)
        {
            //TODO: Add local services;
            return builder;
        }
    }
}
