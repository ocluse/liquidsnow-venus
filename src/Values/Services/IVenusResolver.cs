namespace Ocluse.LiquidSnow.Venus.Services
{
    public interface IVenusResolver
    {
        string ResolveColor(int color);
        string ResolveTextStyle(int textStyle);
        string ResolveTextHierarchy(int textHierarchy);
        string ResolveAvatarId(string userId);
        int ResolveExceptionToContainerState(Exception exception);
    }
}
