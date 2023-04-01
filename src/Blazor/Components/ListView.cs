using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components;

public class ListView<T> : ControlBase
{
    [Parameter]
    public RenderFragment<T>? ItemTemplate { get; set; }
    
    [Parameter]
    public IEnumerable<T>? Items { get; set; }
    
    [Parameter]
    public Func<Task<IEnumerable<T>>>? Fetch { get; set; }

    [Parameter]
    public string? ItemClass { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");

        Dictionary<string, object> attributes = new()
        {
            { "class", GetClass() },
            {"style", GetStyle() },
        };

        builder.AddMultipleAttributes(1, attributes);

        BuildContent(builder);

        builder.CloseElement();
    }

    private void BuildContent(RenderTreeBuilder builder)
    {
        if (Items != null)
        {
            string itemClass = $"list-item {ItemClass}";
            foreach (var item in Items)
            {

                if (ItemTemplate == null)
                {
                    builder.OpenComponent<TextBlock>(2);
                    builder.AddAttribute(2, "ChildContent", item);
                    builder.AddAttribute(2, "Class", itemClass);
                    builder.CloseComponent();
                }
                else
                {
                    builder.OpenElement(2, "div");
                    builder.AddAttribute(2, "class", itemClass);
                    builder.AddContent(3, ItemTemplate, item);
                    builder.CloseElement();
                }
            }
        }
    }

    protected override void BuildClass(List<string> classList)
    {
        base.BuildClass(classList);
        classList.Add("list");
    }

    protected override async Task OnInitializedAsync()
    {
        await ReloadData();
    }
    public async Task ReloadData()
    {
        if (Fetch != null)
        {
            Items = await Fetch.Invoke();
            await InvokeAsync(() => StateHasChanged());
        }
    }
}
