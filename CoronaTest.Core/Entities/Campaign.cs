using System;
using System.Collections.Generic;

namespace CoronaTest.Core.Entities
{
    public class Campaign : EntityObject
    {
        public ICollection<TestCenter> AvailableTestCenter { get; set; }

        public DateTime From { get; set; }
        public string Name { get; set; }
        public DateTime To { get; set; }
        public int Examination { get; set; }
    }
}
