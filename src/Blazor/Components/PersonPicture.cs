using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class Avatar : ControlBase
    {
        [Parameter]
        public string Src { get; set; } = string.Empty;

        [Parameter]
        public string? UserId { get; set; }

        [Parameter]
        public int Size { get; set; } = DefaultSize.Size48;

        protected override void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            classList.Add("avatar");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "img");

            string src = UserId == null ? $"https://cdn.ocluse.com/krystal/avatars/{UserId}" : Src;

            builder.AddAttribute(1, "src", src);
            builder.AddAttribute(2, "height", Size);
            builder.AddAttribute(2, "width", Size);
            builder.AddAttribute(3, "onerror", "this.src ='/images/anonymous.svg';this.onerror=''");
            builder.AddAttribute(4, "class", GetClass());
            builder.CloseElement();
        }
    }
}
