using System;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using CoronaTest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            VerificationTokens = new VerificationTokenRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Validierungen auf Db-Context Ebene
        /// </summary>
        /// <param name="entity"></param>
        public void ValidateEntity(object entity)
        {

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
            if(!_disposed && disposing)
            {
                await _dbContext.DisposeAsync();
            }
            _disposed = true;
        }
    }
}
