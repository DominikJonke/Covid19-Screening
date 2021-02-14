using CoronaTest.Core.Entities;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface ITestCenterRepository
    {
        Task AddRangeAsync(TestCenter[] testCenter);
        Task<int> GetCountAsync();
    }
}
