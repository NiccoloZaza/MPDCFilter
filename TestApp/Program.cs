using System;
using System.Collections.Generic;
using System.Linq;
using MPDCFilter.Abstractions;
using MPDCFilter.Implementations;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ITestObject> testObjects = new List<ITestObject>()
            {
                new TestObject(){ IsSelected = true, Name = "1" },
                new TestObject(){ IsSelected = false, Name = "2" },
                new TestObject(){ IsSelected = false, Name = "3" },
                new TestObject(){ IsSelected = true, Name = "4" },
                new TestObject(){ IsSelected = false, Name = "5" },
            };
            MPDCFilter.MPDCFilter.Instance.TryAddOrUpdate(1, testObjects.Cast<IFilterable>()?.ToList(), new List<MPDCFilter.Abstractions.IFilterGroup>()
            {
                new SwitchStrictGroup()
                {
                    Filters = new List<Filter>()
                    {
                        new Filter()
                        {
                            ID = 0,
                            IsSelected = true,
                            Title = "კი"
                        }
                    },
                    Title = "კი",
                    MultipleSelect = false,
                    Key = "IsSelected"
                }
            });
            var k = MPDCFilter.MPDCFilter.Instance.GetFilterHelper(1).GetFilteredList();
            Console.WriteLine("Hello World!");
        }
    }
}
