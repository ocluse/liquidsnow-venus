using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class ItemContainer<T> : ControlBase
    {
        private ContainerState _state;

        [EditorRequired]
        [Parameter]
        public required RenderFragment<T> ChildContent { get; set; }

        [Parameter]
        public T? Item { get; set; }

        [Parameter]
        public Func<Task<T>>? Fetch { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Fetch != null)
            {
                await ReloadData();
            }
        }

        public async Task ReloadData()
        {
            if (Fetch != null)
            {
                _state = ContainerState.Loading;

                try
                {
                    Item = await Fetch.Invoke();
                }
                catch (Exception ex)
                {
                    //_state = ex.GetContainerState();
                }
                finally
                {
                    await InvokeAsync(() => StateHasChanged());
                }
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if(Item != null)
            {
                builder.AddContent(0, ChildContent, Item);
            }
        }
    }
}
