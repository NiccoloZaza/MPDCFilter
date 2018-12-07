using System;
using System.Collections.Generic;
using System.Text;
using MPDCFilter.Abstractions;
using MPDCFilter.Attributes;

namespace TestApp
{
    public interface ITestObject : IFilterable
    {
        [Filter("IsSelected")]
        bool IsSelected { get; set; }
        string Name { get; set; }
    }

    public class TestObject: ITestObject
    {
        [Filter("IsSelected")]
        public bool IsSelected { get; set; }
        public string Name { get; set; }
    }
}
