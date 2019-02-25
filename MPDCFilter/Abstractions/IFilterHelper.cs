using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Abstractions
{
    public interface IFilterHelper
    {
        int GetCountOfFiltered();

        bool IsFiltered { get; set; }

        void ResetFilters();

        void UndoFilters();

        void ApplyFilters();

        IEnumerable<IFilterGroup> Filters { get; set; }

        IEnumerable<IFilterable> Filterables { get; set; }
    }
}
