using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Abstractions
{
    public interface IFilter
    {
        string Title { get; set; }
        bool IsSelected { get; set; }
        object ID { get; set; }
    }
}
