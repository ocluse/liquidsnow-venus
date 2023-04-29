using Ocluse.LiquidSnow.Venus.Blazor.Components.ContainerStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Services.Implementations
{
    public class BlazorContainerStateResolver : IBlazorContainerStateResolver
    {
        public virtual Type Resolve(int containerState)
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
    }
}
