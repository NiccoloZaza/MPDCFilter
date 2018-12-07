using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Abstractions
{
    public interface IFilterGroup
    {
        bool MultipleSelect { get; set; }
        string Title { get; set; }
        string Key { get; set; }
        IEnumerable<IFilter> Filters { get; set; }
    }
}
