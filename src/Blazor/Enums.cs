namespace Ocluse.LiquidSnow.Venus.Blazor
{

    public enum Keyboard
    {
        Text,
        Email,
        File,
        Date,
        DateTimeLocal,
        Hidden,
        Image,
        Month,
        Number,
        Password,
        Week,
        Tel
    }

    public enum ContainerState
    {
        Loading,
        NotFound,
        Error,
        Unauthorized,
        Found,
        ReauthenticationRequired
    }
}
