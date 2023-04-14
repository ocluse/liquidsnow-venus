using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Ocluse.LiquidSnow.Venus.Blazor.Services;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components;

public class ListView<T> : ControlBase
{
    [Inject]
    public IBlazorContainerStateResolver ContainerStateResolver { get; } = null!;

    [Parameter]
    public RenderFragment<T>? ItemTemplate { get; set; }
    
    [Parameter]
    public IEnumerable<T>? Items { get; set; }
    
    [Parameter]
    public Func<Task<IEnumerable<T>>>? Fetch { get; set; }

    [Parameter]
    public string? ItemClass { get; set; }

    [Parameter]
    public int State { get; set; }

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
                    builder.SetKey(item);
                    builder.AddAttribute(3, nameof(TextBlock.ChildContent), item);
                    builder.AddAttribute(4, nameof(TextBlock.Class), itemClass);
                    builder.CloseComponent();
                }
                else
                {
                    builder.OpenElement(5, "div");
                    builder.SetKey(item);
                    builder.AddAttribute(6, "class", itemClass);
                    builder.AddContent(7, ItemTemplate, item);
                    builder.CloseElement();
                }
               
            }
        }
        else
        {
            Type typeToRender = ContainerStateResolver.Resolve(State);
            builder.OpenComponent(8, typeToRender);
            builder.CloseComponent();
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
            State = ContainerState.Loading;

            try
            {
                Items = await Fetch.Invoke();
            }
            catch (Exception ex)
            {
                State = VenusResolver.ResolveExceptionToContainerState(ex);
            }
            finally
            {
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
