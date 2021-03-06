﻿using CoronaTest.Core.DTO;
using CoronaTest.Core.Entities;
using CoronaTest.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTest.Persistence.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ExaminationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Examination[]> GetExaminationByParticipant(int id)
        {
            return await _dbContext.Examination
                .Where(p => p.Participant.Id == id)
                .ToArrayAsync();

        }

        public async Task<ExaminationsDto[]> GetExaminationByDate(DateTime? from, DateTime? to)
        {
            return await _dbContext.Examination
               .Include(p => p.Participant)
               .Select(s => new ExaminationsDto(s))
               .ToArrayAsync();
        }
    }
}
