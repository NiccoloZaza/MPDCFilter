using System;
using System.Collections.Generic;
using System.Text;
using MPDCFilter.Abstractions;

namespace MPDCFilter.Implementations
{
    public class SwitchStrictGroup : ISwitchStrictGroup
    {
        public bool MultipleSelect { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public IEnumerable<IFilter> Filters { get; set; }
    }
}
