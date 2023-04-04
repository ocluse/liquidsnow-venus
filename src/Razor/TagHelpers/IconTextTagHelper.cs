using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Ocluse.LiquidSnow.Venus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ocluse.LiquidSnow.Venus.Razor.TagHelpers
{
    public class IconTextTagHelper : TagHelperControlBase
    {
        public IconTextTagHelper(IVenusResolver venusResolver) : base(venusResolver)
        {
        }

        public string Icon { get; set; } = string.Empty;

        public int IconSize { get; set; } = DefaultSize.Size18;

        public int? IconColor { get; set; }

        public int TextStyle { get; set; } = Venus.TextStyle.Body;

        protected override void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            classList.Add("icon-text");
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            output.TagName = "div";
            AddClassAndSetStyle(output);

            using var writer = new StringWriter();

            WriteIcon(context, writer);
            WriteText(context, writer, content);

            output.Content.SetHtmlContent(writer.ToString());
        }

        private void WriteIcon(TagHelperContext context, TextWriter writer)
        {
            FeatherIconTagHelper navIcon = new(_venusResolver)
            {
                Icon = Icon,
                Size = IconSize,
                Color = IconColor,
            };

            TagHelperOutput iconOutput = new(
                tagName: "",
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (useCachedResult, encoder) =>
                Task.Factory.StartNew<TagHelperContent>(
                    () => new DefaultTagHelperContent()));

            navIcon.Process(context, iconOutput);

            iconOutput.WriteTo(writer, NullHtmlEncoder.Default);
        }

        private void WriteText(TagHelperContext context, TextWriter writer, TagHelperContent content)
        {
            TextBlockTagHelper navText = new(_venusResolver)
            {
                Hierarchy = TextHierarchy.Span,
                TextStyle = TextStyle
            };

            TagHelperOutput textOutput = new(
                tagName: "",
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (useCachedResult, encoder) =>
                Task.Factory.StartNew<TagHelperContent>(
                    () => new DefaultTagHelperContent()));

            navText.Process(context, textOutput);

            textOutput.Content = content;

            textOutput.WriteTo(writer, NullHtmlEncoder.Default);
        }
    }
}
