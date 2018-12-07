﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPDCFilter.Abstractions;
using MPDCFilter.Implementations;

namespace MPDCFilter
{
    public class MPDCFilter
    {
        private static MPDCFilter _instance = null;

        private Dictionary<object, IFilterHelper> FilterHelpers { get; set; }

        private MPDCFilter()
        {
            FilterHelpers = new Dictionary<object, IFilterHelper>();
        }

        public static MPDCFilter Instance 
            {
            get 
                {
                if (_instance == null)
                    _instance = new MPDCFilter();
                return _instance;
            }
        }

        public IFilterHelper GetFilterHelper(object Key)
        {
            if (FilterHelpers.TryGetValue(Key, out IFilterHelper value))
            {
                return value;
            }
            return null;
        }

        public void TryAddOrUpdate(object Key, List<IFilterable> Filterables, List<IFilterGroup> Filters)
        {
            if (FilterHelpers.ContainsKey(Key))
            {
                FilterHelpers.Remove(Key);
                FilterHelpers.Add(Key, new FilterHelper()
                {
                    Filterables = Filterables,
                    Filters = Filters,
                    IsFiltered = false
                });
                return;
            }
            FilterHelpers.Add(Key, new FilterHelper()
            {
                Filterables = Filterables,
                Filters = Filters,
                IsFiltered = false
            });
        }
    }
}
