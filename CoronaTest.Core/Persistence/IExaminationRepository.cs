using CoronaTest.Core.DTO;
using CoronaTest.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CoronaTest.Core.Persistence
{
    public interface IExaminationRepository
    {
        public Task<Examination[]> GetExaminationByParticipant(int id);
        Task<ExaminationsDto[]> GetExaminationByDate(DateTime? from, DateTime? to); 
    }
}
