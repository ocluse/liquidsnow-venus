using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus
{
    public interface IGrid
    {
        int Columns { get; set; }
        int? ColumnsLg { get; set; }
        int? ColumnsMd { get; set; }
        int? ColumnsSm { get; set; }
        int? ColumnsXs { get; set; }
        int Gap { get; set; }
        int? ColumnGap { get; set; }
        int? RowGap { get; set; }
    }

    public static class GridExtensions
    {
        public static IEnumerable<string> GetGridStyles(this IGrid grid)
        {
            List<string> styleList = new()
            {
                $"--grid-columns:{TranslateToGridTemplate(grid.Columns)}"
            };

            //Lg:
            int lg = grid.ColumnsLg ?? grid.Columns;
            styleList.Add($"--grid-columns-lg: {TranslateToGridTemplate(lg)}");

            //Md:
            int md = grid.ColumnsMd ?? lg;
            styleList.Add($"--grid-columns-md: {TranslateToGridTemplate(md)}");

            //Sm:
            int sm = grid.ColumnsSm ?? md;
            styleList.Add($"--grid-columns-sm: {TranslateToGridTemplate(sm)}");

            //Xs:
            int xs = grid.ColumnsXs ?? sm;
            styleList.Add($"--grid-columns-xs: {TranslateToGridTemplate(xs)}");

            //Column Gap
            int columnGap = grid.ColumnGap ?? grid.Gap;
            styleList.Add($"--grid-column-gap: {columnGap / 2}rem");

            //Row Gap
            int rowGap = grid.RowGap ?? grid.Gap;
            styleList.Add($"--grid-row-gap: {rowGap / 2}rem;");

            return styleList;
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

