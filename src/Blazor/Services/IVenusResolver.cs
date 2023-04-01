using Ocluse.LiquidSnow.Venus.Blazor.Components;

namespace Ocluse.LiquidSnow.Venus.Blazor.Services
{
    public interface IVenusResolver
    {
        public string ResolveColor(int color);
        public string ResolveTextStyle(int textStyle);
        public string ResolveTextHierarchy(int textHierarchy);
    }
}
