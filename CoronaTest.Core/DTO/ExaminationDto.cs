using CoronaTest.Core.Entities;
using CoronaTest.Core.Enum;
using System;

namespace CoronaTest.Core.DTO
{
    public class ExaminationsDto
    {
        public int Id { get; set; }
        public string ParticipantFullname { get; set; }
        public TestResult TestResult { get; set; }
        public DateTime ExaminationAt { get; set; }
        public string Identifier { get; set; }
        public ExaminationsDto(Examination examination)
        {
            Id = examination.Id;
            ParticipantFullname = $"{examination.Participant.FirstName} {examination.Participant.LastName}";
            TestResult = examination.TestResult;
            ExaminationAt = examination.ExaminationAt;
            Identifier = examination.Identifier;
        }
    }
}
