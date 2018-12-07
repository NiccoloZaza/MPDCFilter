using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Abstractions
{
    public interface IFilterHelper
    {
        bool IsFiltered { get; set; }

        IEnumerable<IFilterGroup> Filters { get; set; }

        IEnumerable<IFilterable> Filterables { get; set; }

        int GetCountOfFiltered();

        void ResetFilters();

        void UndoFilters();

        void ApplyFilters();

        List<IFilterable> GetFilteredList();
    }
}
