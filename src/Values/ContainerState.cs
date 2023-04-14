namespace Ocluse.LiquidSnow.Venus
{
    public class ContainerState
    {
        public static int Loading { get; } = 1;
        public static int NotFound { get; } = 2;
        public static int Error { get; } = 3;
        public static int Unauthorized { get; } = 4;
        public static int Found { get; } = 5;
        public static int ReauthenticationRequired { get; } = 6;
    }
}