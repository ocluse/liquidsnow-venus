using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components;

public abstract class ButtonBase : ControlBase
{
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "a");
        Dictionary<string, object> attributes = new()
        {
            { "class", GetClass() },
            {"style", GetStyle() },
            {"onclick", OnClick }
        };

        if (Href == null)
        {
            attributes.Add("role", "button");
        }
        else
        {
            attributes.Add("href", Href);

            if (!string.IsNullOrEmpty(Target))
            {
                attributes.Add("target", Target);
            }
        }

        builder.AddMultipleAttributes(1, attributes);

        BuildContent(builder);

        builder.CloseElement();
    }

    protected abstract void BuildContent(RenderTreeBuilder builder);
}
