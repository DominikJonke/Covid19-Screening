using CoronaTest.Core.Entities;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface IParticipantRepository
    {
        Task AddRangeAsync(Participant[] participants);
        Task<int> GetCountAsync();
        Task AddAsync(Participant participant);

        public Task<Participant> GetByParticipantByNumberAsync(string socialSecurityNumber);
        Task<Participant> GetByIdAsync(int id);
    }
}
