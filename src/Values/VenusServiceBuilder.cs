using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus
{
    public class VenusServiceBuilder
    {
        private readonly IServiceCollection _services;

        internal IServiceCollection Services => _services;

        internal VenusServiceBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public VenusServiceBuilder AddResolver<T>() where T : class, IVenusResolver
        {
            //Remove existing type:
            Services.RemoveAll(typeof(IVenusResolver));
            Services.AddSingleton<IVenusResolver, T>();

            return this;
        }
    }
}
