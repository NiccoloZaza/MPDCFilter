using System;
using System.Collections.Generic;
using System.Text;
using MPDCFilter.Abstractions;

namespace MPDCFilter.Implementations
{
    public class Filter : IFilter
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }
        public object ID { get; set; }
    }
}
