using Ocluse.LiquidSnow.Venus.Blazor.Contracts;
using Ocluse.LiquidSnow.Venus.Blazor.Models;

namespace Ocluse.LiquidSnow.Venus.Blazor.Services.Implementations
{
    internal class SnackbarService : ISnackbarService
    {
        private ISnackbarHost? _host;
        public void AddError(string message, SnackbarDuration duration = SnackbarDuration.Medium)
        {
            SnackbarMessage snackbarMessage = new() 
            { 
                Content = message, 
                Status = MessageStatus.Error, 
                Duration = duration 
            };

            _host?.ShowMessage(snackbarMessage);
        }

        public void AddInformation(string message, SnackbarDuration duration = SnackbarDuration.Medium)
        {
            SnackbarMessage snackbarMessage = new()
            {
                Content = message,
                Status = MessageStatus.Information,
                Duration = duration
            };

            _host?.ShowMessage(snackbarMessage);
        }

        public void AddSuccess(string message, SnackbarDuration duration = SnackbarDuration.Medium)
        {
            SnackbarMessage snackbarMessage = new()
            {
                Content = message,
                Status = MessageStatus.Success,
                Duration = duration
            };

            _host?.ShowMessage(snackbarMessage);
        }

        public void AddWarning(string message, SnackbarDuration duration = SnackbarDuration.Medium)
        {
            SnackbarMessage snackbarMessage = new()
            {
                Content = message,
                Status = MessageStatus.Warning,
                Duration = duration
            };

            _host?.ShowMessage(snackbarMessage);
        }

        public void SetHost(ISnackbarHost host)
        {
            _host = host;
        }
    }
}
