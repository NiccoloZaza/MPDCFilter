using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPDCFilter.Abstractions;
using MPDCFilter.Extensions;

namespace MPDCFilter.Implementations
{
    public class OnlineFilterHelper : IOnlineFilterHelper
    {
        public Task<IEnumerable<IFilterable>> GetOnlineDataAsync { get; set; }
        public bool IsFiltered { get; set; }
        public IEnumerable<IFilterGroup> Filters { get; set; }
        public IEnumerable<IFilterable> Filterables { get; set; }

        private List<bool> selectedValues { get; set; }

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

        public int GetCountOfFiltered()
        {
            var filteredData = Filterables.GetFilteredList(this);
            if (filteredData == null)
                return 0;
            return filteredData.Count;
        }

        public async Task<List<IFilterable>> GetFilteredListAsync()
        {
            Filterables = await GetOnlineDataAsync;
            return Filterables.GetFilteredList(this);
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

        Task<List<IFilterable>> IOnlineFilterHelper.GetFilteredList()
        {
            throw new NotImplementedException();
        }
    }
}
