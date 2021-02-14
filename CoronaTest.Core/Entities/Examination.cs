using CoronaTest.Core.Enum;
using System;

namespace CoronaTest.Core.Entities
{
    public class Examination : EntityObject
    {
        public Participant Participant { get; set; }
        public ExaminationState State { get; set; }
        public TestResult Result { get; set; }
        public Campaign Campaign { get; set; }
        public TestCenter TestCenter { get; set; }

        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }

        public static Examination CreateNew()
        {
            return new Examination();
        }
    }
}
