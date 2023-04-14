using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Services
{
    public interface IBlazorContainerStateResolver
    {
        Type Resolve(int containerState);
    }
}
