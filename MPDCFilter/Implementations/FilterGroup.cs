using System;
using System.Collections.Generic;
using System.Text;
using MPDCFilter.Abstractions;

namespace MPDCFilter.Implementations
{
    public class FilterGroup : IFilterGroup
    {
        public string Title { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
        public string Key { get; set; }
        public bool MultipleSelect { get; set; }
    }
}
