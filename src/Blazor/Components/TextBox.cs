using Microsoft.AspNetCore.Components;
using Ocluse.LiquidSnow.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{

    public class TextBox : InputControlBase<string>
    {
        [Parameter]
        public Keyboard InputType { get; set; }

        protected override string? GetValue(object? value)
        {
            return value?.ToString() ?? string.Empty;
        }

        protected override string GetInputType()
        {
            return InputType.ToString().PascalToKebabCase();
        }
    }
}
