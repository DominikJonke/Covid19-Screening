using CoronaTest.Core.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class TestCenterRepository : ITestCenterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestCenterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRangeAsync(TestCenter[] testCenters)
        {
            await _dbContext.TestCenter.AddRangeAsync(testCenters);
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.TestCenter.CountAsync();
        }
    }
}
