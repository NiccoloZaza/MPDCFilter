using System;
using System.Collections.Generic;
using System.Text;

namespace MPDCFilter.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterAttribute : System.Attribute
    {
        public string Key { get; }
        public FilterAttribute(string key) => Key = key;
    }
}
