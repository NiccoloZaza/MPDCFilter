using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPDCFilter.Abstractions
{
    public interface IOnlineFilterHelper:IFilterHelper
    {
        Task<List<IFilterable>> GetFilteredList();
        Task<IEnumerable<IFilterable>> GetOnlineDataAsync { get; set; }
    }
}
