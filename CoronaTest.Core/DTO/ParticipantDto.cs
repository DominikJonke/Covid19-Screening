using CoronaTest.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaTest.Core.DTO
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public string CampaignName { get; set; }
        public string TestCenterName { get; set; }
        public TestResult Testresult { get; set; }
    }
}
