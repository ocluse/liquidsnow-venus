using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class ChipSelect<T> : InputBase<T>
    {
        [Parameter]
        public IEnumerable<T>? Items { get; set; }

        [Parameter]
        public RenderFragment<T>? ItemTemplate { get; set; }

        protected override T? GetValue(object? value)
        {
            return (T?)value;
        }

        protected override void BuildInputClass(List<string> classList)
        {
            base.BuildInputClass(classList);
            classList.Add("chip-select");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", GetClass());
            if (Items != null)
            {
                foreach (T item in Items)
                {
                    builder.OpenElement(2, "div");
                    builder.AddAttribute(3, "class", item.Equals(Value) ? "option active" : "option");
                    builder.AddAttribute(4, "onclick", () => OnClick(item));
                    if (ItemTemplate == null)
                    {
                        builder.AddAttribute(5, "style", "padding: 1rem;");
                        //builder.AddContent(5, item.ToString());
                        builder.OpenElement(6, "div");
                        builder.AddContent(7, item.ToString());
                        builder.CloseElement();
                        //builder.OpenComponent<TextBlock>(5);
                        //builder.AddAttribute(6, "Margin", "2");
                        //builder.AddAttribute(7, nameof(TextBlock.ChildContent), RenderFragment.Create item);
                        //builder.CloseComponent();
                    }
                    else
                    {
                        builder.AddContent(8, ItemTemplate, item);
                    }
                    builder.CloseComponent();
                }
            }
            builder.CloseElement();
        }

        private async Task OnClick(T value)
        {
            ChangeEventArgs args = new() { Value = value };
            await OnChange(args);
        }
    }
}
