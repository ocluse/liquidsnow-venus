﻿using Ocluse.LiquidSnow.Venus.Blazor.Components.ContainerStates;

namespace Ocluse.LiquidSnow.Venus.Blazor.Services.Implementations
{
    public class BlazorResolver : IBlazorResolver
    {
        public virtual Type ResolveContainerStateToRenderType(int containerState)
        {
            return containerState switch
            {
                ContainerState.Loading => typeof(Loading),
                ContainerState.NotFound => typeof(NotFound),
                ContainerState.Empty => typeof(Empty),
                ContainerState.Error => typeof(Error),
                ContainerState.Unauthorized => typeof(Unauthorized),
                ContainerState.ReauthenticationRequired => typeof(ReauthenticationRequired),
                _ => throw new NotImplementedException()
            };
        }

        public virtual string ResolveSnackbarStatusToIcon(int status)
        {
            return status switch
            {
                MessageStatus.Error => Icons.Feather.XCircle,
                MessageStatus.Information => Icons.Feather.Info,
                MessageStatus.Success => Icons.Feather.CheckCircle,
                MessageStatus.Warning => Icons.Feather.AlertTriangle,
                _ => throw new NotImplementedException()
            };
        }

        public virtual int ResolveSnackbarStatusToColor(int status)
        {
            return status switch
            {
                MessageStatus.Error => Color.Error,
                MessageStatus.Information => Color.Primary,
                MessageStatus.Success => Color.Success,
                MessageStatus.Warning => Color.Warning,
                _ => throw new NotImplementedException()
            };
        }

        public virtual int ResolveSnackbarDurationToMilliseconds(SnackbarDuration duration)
        {
            return duration switch
            {
                SnackbarDuration.Short => 3000,
                SnackbarDuration.Medium => 5000,
                SnackbarDuration.Long => 8000,
                SnackbarDuration.Infinite => 0,
                _ => throw new NotImplementedException()
            };
        }
    }
}
