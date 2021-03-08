using CoronaTest.Core.Contracts;
using CoronaTest.Core.Models;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AuthUser user)
        {
            await _dbContext.User
                    .AddAsync(user);
        }
    }
}
