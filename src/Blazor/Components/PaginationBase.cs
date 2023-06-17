using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class PaginationBase : ControlBase
    {
        [Parameter]
        public RenderFragment? PaginationNextContent { get; set; }

        [Parameter]
        public RenderFragment? PaginationBackContent { get; set; }

        protected override void BuildClass(List<string> classList)
        {
            classList.Add("pagination");
            base.BuildClass(classList);
        }
    }
}
