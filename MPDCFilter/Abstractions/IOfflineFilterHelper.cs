using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Abstractions
{
    public interface IOfflineFilterHelper: IFilterHelper
    {
        List<IFilterable> GetFilteredList();
    }
}
