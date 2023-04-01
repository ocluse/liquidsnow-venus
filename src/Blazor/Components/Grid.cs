using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Ocluse.LiquidSnow.Venus.Blazor.Components
{
    public class Grid : ControlBase
    {
        [Parameter]
        public int Columns { get; set; } = 1;

        [Parameter]
        public int? ColumnsLg { get; set; }

        [Parameter]
        public int? ColumnsMd { get; set; }

        [Parameter]
        public int? ColumnsSm { get; set; }

        [Parameter]
        public int? ColumnsXs { get; set; }

        [Parameter]
        public int Gap { get; set; }

        [Parameter]
        public int? ColumnGap { get; set; }

        [Parameter]
        public int? RowGap { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

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

        protected virtual void BuildContent(RenderTreeBuilder builder)
        {
            if (ChildContent != null)
            {
                builder.AddContent(2, ChildContent);
            }
        }

        protected override void BuildClass(List<string> classList)
        {
            base.BuildClass(classList);
            classList.Add("grid");
        }

        protected override void BuildStyle(List<string> styleList)
        {
            base.BuildStyle(styleList);

            styleList.Add($"--grid-columns:{TranslateToGridTemplate(Columns)}");

            //Lg:
            int lg = ColumnsLg ?? Columns;
            styleList.Add($"--grid-columns-lg: {TranslateToGridTemplate(lg)}");

            //Md:
            int md = ColumnsMd ?? lg;
            styleList.Add($"--grid-columns-md: {TranslateToGridTemplate(md)}");

            //Sm:
            int sm = ColumnsSm ?? md;
            styleList.Add($"--grid-columns-sm: {TranslateToGridTemplate(sm)}");

            //Xs:
            int xs = ColumnsXs ?? sm;
            styleList.Add($"--grid-columns-xs: {TranslateToGridTemplate(xs)}");

            //Column Gap
            int columnGap = ColumnGap ?? Gap;
            styleList.Add($"--grid-column-gap: {columnGap / 2}rem");

            //Row Gap
            int rowGap = RowGap ?? Gap;
            styleList.Add($"--grid-row-gap: {rowGap / 2}rem;");
        }

        private static string TranslateToGridTemplate(int columns)
        {
            StringBuilder sb = new();
            for (int i = 0; i < columns; i++)
            {
                sb.Append("1fr ");
            }
            return sb.ToString().Trim();
        }
    }
}
