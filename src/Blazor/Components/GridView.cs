using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components;

public class GridView<T> : Grid
{
    [Parameter]
    public RenderFragment<T>? ItemTemplate { get; set; }

    [Parameter]
    public IEnumerable<T>? Items { get; set; }

    [Parameter]
    public Func<Task<IEnumerable<T>>>? Fetch { get; set; }

    protected override void BuildContent(RenderTreeBuilder builder)
    {
        if (Items != null)
        {
            foreach (var item in Items)
            {
                if (ItemTemplate == null)
                {
                    builder.OpenComponent<TextBlock>(2);
                    builder.AddAttribute(2, "ChildContent", item);
                    builder.CloseComponent();
                }
                else
                {
                    builder.AddContent(2, ItemTemplate, item);
                }
            }
        }
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
