using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocluse.LiquidSnow.Venus.Blazor.Models
{
    public class FilterOption
    {
        public required string Name { get; set; }
        public required object Value { get; set; }
    }

    public class FiltrationOptions
    {
        public required List<FilterOption> Filters { get; set; }
        public required List<SortOption> Sorters { get; set; }

        public required SortOption DefaultSort { get; set; }
        public required FilterOption DefaultFilter { get; set; }
    }
}
