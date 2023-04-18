using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class CheckBox : InputBase<bool>
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        protected override void BuildInputClass(List<string> classList)
        {
            base.BuildInputClass(classList);
            classList.Add("checkbox");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "label");
            builder.AddAttribute(1, "class", GetClass());
            builder.AddAttribute(2, "style", GetStyle());

            builder.AddContent(3, ChildContent);

            builder.OpenElement(4, "input");
            builder.AddAttribute(5, "type", "checkbox");
            builder.AddAttribute(6, "onchange", OnChange);
            builder.AddAttribute(7, "checked", Value);
            builder.CloseElement();

            builder.OpenElement(8, "span");
            builder.AddAttribute(9, "class", "checkmark");
            builder.CloseElement();

            builder.CloseElement();
        }

        protected override bool GetValue(object? value)
        {
            if(bool.TryParse(value?.ToString(), out bool result))
            {
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
