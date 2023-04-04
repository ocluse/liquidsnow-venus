using Microsoft.AspNetCore.Components;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus.Razor.TagHelpers
{
    public abstract class TagHelperControlBase : TagHelperElementBase
    {
        public int? Color { get; set; }

        public int? BackgroundColor { get; set; }

        protected IVenusResolver _venusResolver;

        public TagHelperControlBase(IVenusResolver venusResolver)
        {
            _venusResolver = venusResolver;
        }

        protected override void BuildStyle(List<string> styleList)
        {
            base.BuildStyle(styleList);
            if (Color != null)
            {
                styleList.Add($"color: {_venusResolver.ResolveColor(Color.Value)}");
            }
            if (BackgroundColor != null)
            {
                styleList.Add($"background-color: {_venusResolver.ResolveColor(BackgroundColor.Value)}");
            }
        }
    }
}
