using CoronaTest.Core.Contracts;
using CoronaTest.Core.Models;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Role role)
        {
            await _dbContext.Role.AddAsync(role);
        }
    }
}
