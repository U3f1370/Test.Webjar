using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        public DbContext DbContext { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        //void BeginTransaction();
        //void RollbackTransaction();
        //void CommitTransaction();

        //void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        //void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
