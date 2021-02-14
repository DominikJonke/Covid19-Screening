using CoronaTest.Core.Entities;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface ICampaignRepository
    {
        Task AddRangeAsync(Campaign[] campaigns);
        Task<int> GetCountAsync();
    }
}
