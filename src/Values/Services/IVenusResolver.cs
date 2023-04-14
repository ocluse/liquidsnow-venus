namespace Ocluse.LiquidSnow.Venus.Services
{
    public interface IVenusResolver
    {
        public string ResolveColor(int color);
        public string ResolveTextStyle(int textStyle);
        public string ResolveTextHierarchy(int textHierarchy);
        public string ResolveAvatarId(string userId);
        public int ResolveExceptionToContainerState(Exception exception);
    }
}
