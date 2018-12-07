using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPDCFilter.Abstractions;
using MPDCFilter.Attributes;

namespace MPDCFilter.Extensions
{
    public static class FilterExtensions
    {
        public static List<T> GetFilteredList<T>(this IEnumerable<T> list, IFilterHelper filterHelper) where T : IFilterable
        {
            List<T> tmp = new List<T>();
            tmp.AddRange(list);
            for (int i = 0; i < filterHelper?.Filters?.Count(); i++)
            {
                var current = filterHelper?.Filters.ElementAt(i);
                if (current is ISwitchFilterGroup)
                {
                    continue;
                }
                var key = current.Key;
                try
                {
                    var type = list.FirstOrDefault()?.GetType();
                    var properties = type.GetProperties().Where(x => x.CustomAttributes != null && x.CustomAttributes.Count() > 0).ToList();
                    var property = properties.FirstOrDefault(x => x.GetCustomAttributes(typeof(FilterAttribute), false) != null && (x.GetCustomAttributes(typeof(FilterAttribute), false).First() as FilterAttribute).Key == key);
                    if (filterHelper?.Filters.ElementAt(i).Filters.Count(x => x.IsSelected) == 0)
                    {
                        continue;
                    }
                    filterHelper.IsFiltered = true;
                    var selectedFilters = filterHelper?.Filters?.ElementAt(i)?.Filters?.Where(p => p.IsSelected).ToList();
                    tmp.RemoveAll(x => selectedFilters?.FirstOrDefault(e => e.ID.Equals(property.GetValue(x))) == null);
                }
                catch (Exception) { }
            }
            foreach (var item in filterHelper?.Filters?.Where(x => x is ISwitchStrictGroup))
            {
                try
                {
                    if (item.Filters.FirstOrDefault().IsSelected)
                    {
                        var type = list.FirstOrDefault()?.GetType();
                        var properties = type.GetProperties().Where(x => x.CustomAttributes != null && x.CustomAttributes.Count() > 0).ToList();
                        var property = properties.FirstOrDefault(x => x.GetCustomAttributes(typeof(FilterAttribute), false) != null && (x.GetCustomAttributes(typeof(FilterAttribute), false).First() as FilterAttribute).Key == item.Key);
                        tmp = tmp?.Where(x => (bool)property.GetValue(x))?.ToList();
                        filterHelper.IsFiltered = true;
                        continue;
                    }
                }
                catch (Exception) { }
            }
            foreach (var item in filterHelper?.Filters?.Where(x => x is ISwitchSortGroup))
            {
                try
                {
                    if (!item.Filters.FirstOrDefault().IsSelected)
                    {
                        var type = list.FirstOrDefault()?.GetType();
                        var properties = type.GetProperties().Where(x => x.CustomAttributes != null && x.CustomAttributes.Count() > 0).ToList();
                        var property = properties.FirstOrDefault(x => x.GetCustomAttributes(typeof(FilterAttribute), false) != null && (x.GetCustomAttributes(typeof(FilterAttribute), false).First() as FilterAttribute).Key == item.Key);
                        if (item.Filters.ElementAt(1).IsSelected)
                        {
                            tmp = tmp.OrderBy(x => property.GetValue(x))?.ToList();
                            filterHelper.IsFiltered = true;
                        }
                        else if (item.Filters.ElementAt(2).IsSelected)
                        {
                            tmp = tmp.OrderByDescending(x => property.GetValue(x))?.ToList();
                            filterHelper.IsFiltered = true;
                        }
                    }
                }
                catch (Exception) { }
            }
            return tmp;
        }
    }
}
