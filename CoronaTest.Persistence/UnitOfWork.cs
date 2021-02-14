﻿using System;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using CoronaTest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CoronaTest.Core.Entities;
using System.ComponentModel.DataAnnotations;
using CoronaTest.Core.Persistence;

namespace CoronaTest.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationDbContext _dbContext;
        public IVerificationTokenRepository VerificationTokens { get; private set; }
        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            CampaignRepository = new CampaignRepository(_dbContext);
            TestCenterRepository = new TestCenterRepository(_dbContext);
            ParticipantRepository = new ParticipantRepository(_dbContext);
            ExaminationRepository = new ExaminationRepository(_dbContext);
            VerificationTokens = new VerificationTokenRepository(_dbContext);
        }

        public ICampaignRepository CampaignRepository { get; }
        public IExaminationRepository ExaminationRepository { get; }
        public ITestCenterRepository TestCenterRepository { get; }
        public IParticipantRepository ParticipantRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                await ValidateEntity(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Validierungen auf Db-Context Ebene
        /// </summary>
        /// <param name="entity"></param>
        public async Task ValidateEntity(object entity)
        {
            if (entity is Participant participant)
            {
                if (await _dbContext.Participant.AnyAsync(p => p.Id != participant.Id && p.SocialSecurityNumber == participant.SocialSecurityNumber))
                {
                    throw new ValidationException($"Eine Person mit der Sozialversicherungsnummer {participant.SocialSecurityNumber} ist bereits registriert.");

                }
            }
        }

        public async Task DeleteDatabaseAsync() => await _dbContext.Database.EnsureDeletedAsync();
        public async Task MigrateDatabaseAsync() => await _dbContext.Database.MigrateAsync();
        public async Task CreateDatabaseAsync() => await _dbContext.Database.EnsureCreatedAsync();

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        public virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed && disposing)
            {
                await _dbContext.DisposeAsync();
            }
            _disposed = true;
        }
    }
}
