using Microsoft.AspNetCore.Razor.TagHelpers;
using Ocluse.LiquidSnow.Venus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Razor.TagHelpers
{
    public class ReadingContainerTagHelper : TagHelperControlBase
    {
        public ReadingContainerTagHelper(IVenusResolver venusResolver) : base(venusResolver)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            AddClassAndSetStyle(output);
        }

        protected override void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            classList.Add("reading-container");
        }
    }
}
