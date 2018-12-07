using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPDCFilter.Abstractions;
using MPDCFilter.Extensions;

namespace MPDCFilter.Implementations
{
    public class FilterHelper:IFilterHelper
    {
        public IEnumerable<IFilterGroup> Filters {
            get { return filters; }
            set {
                filters = value;
                selectedValues = new List<bool>();
                foreach (var item in filters)
                {
                    foreach (var innerItem in item.Filters)
                    {
                        selectedValues.Add(innerItem.IsSelected);
                    }
                }
            }
        }

        private IEnumerable<IFilterGroup> filters;

        public IEnumerable<IFilterable> Filterables { get; set; }

        private List<bool> selectedValues { get; set; }
        public bool IsFiltered { get; set; }

        public void ApplyFilters()
        {
            int i = 0;
            foreach (var item in Filters)
            {
                foreach (var filter in item.Filters)
                {
                    selectedValues[i++] = filter.IsSelected;
                }
            }
        }

        public void UndoFilters()
        {
            int i = 0;
            foreach (var item in Filters)
            {
                foreach (var filter in item.Filters)
                {
                    filter.IsSelected = selectedValues[i++];
                }
            }
        }

        public int GetCountOfFiltered()
        {
            var filteredData = Filterables.GetFilteredList(this);
            if (filteredData == null)
                return 0;
            return filteredData.Count;
        }

        public void ResetFilters()
        {
            foreach (var item in Filters)
            {
                foreach (var innerItem in item.Filters)
                {
                    innerItem.IsSelected = false;
                }
                if (item is ISwitchSortGroup)
                {
                    item.Filters.ElementAt(0).IsSelected = true;
                }
            }
        }

        public List<IFilterable> GetFilteredList()
        {
            return Filterables.GetFilteredList(this);
        }
    }
}
