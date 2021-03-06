﻿using CoronaTest.Core.Persistence;
using System;
using System.Threading.Tasks;

namespace CoronaTest.Core.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IVerificationTokenRepository VerificationTokens { get; }

        ICampaignRepository CampaignRepository { get; }
        ITestCenterRepository TestCenterRepository { get; }
        IExaminationRepository ExaminationRepository { get; }
        IParticipantRepository ParticipantRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }

        Task<int> SaveChangesAsync();
        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
        Task CreateDatabaseAsync();
    }
}
