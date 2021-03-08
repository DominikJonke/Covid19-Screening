using System.Collections.Generic;

namespace CoronaTest.Core.Entities
{
    public class TestCenter : EntityObject
    {
        public ICollection<Campaign> AvailableInCampaign { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public int SlotCapacity { get; set; }
        public string Street { get; set; }
    }
}
