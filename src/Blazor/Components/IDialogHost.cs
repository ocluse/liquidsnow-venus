namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public interface IDialogHost
    {
        Task<DialogResult> ShowDialog(Type dialogType, string? dialogHeader, bool allowDismiss, bool showClose, Dictionary<string, object>? parameters);
        void CloseDialog(bool? isSuccess = null, object? data = null);
    }
}
