using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ocluse.LiquidSnow.Core.Extensions;
using Ocluse.LiquidSnow.Venus.Services;

namespace Ocluse.LiquidSnow.Venus.Razor.TagHelpers
{
    public class TextBlockTagHelper : TagHelperControlBase
    {
        public int Hierarchy { get; set; } = TextHierarchy.Span;
        public int TextStyle { get; set; } = Venus.TextStyle.Body;

        public TextBlockTagHelper(IVenusResolver venusResolver) : base(venusResolver)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Set the tag name
            output.TagName = _venusResolver.ResolveTextHierarchy(Hierarchy);

            AddClassAndSetStyle(output);
        }

        protected override void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            classList.Add(_venusResolver.ResolveTextStyle(TextStyle));
        }
    }
}
