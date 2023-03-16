using Common.Utilities;
using Entities;
using Entities.Product;
using Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbContext DbContext { get { return this; } }
        private IDbContextTransaction _transaction;
        private void ChangeDateEntities()
        {
            var addedEntities = ChangeTracker.Entries().Where(z => z.State == EntityState.Added).ToList();
            addedEntities.ForEach((x) =>
            {
                if (x.Properties.Any(z => z.Metadata.Name == "CreateDm"))
                    x.Property("CreateDm").CurrentValue = DateTime.Now;
            });

            var modifiedEntities = ChangeTracker.Entries().Where(z => z.State == EntityState.Modified).ToList();
            modifiedEntities.ForEach((x) =>
            {
                if (x.Properties.Any(z => z.Metadata.Name == "LastUpdateDm"))
                    x.Property("LastUpdateDm").CurrentValue = DateTime.Now;
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(IEntityApp).Assembly;

            modelBuilder.RegisterAllEntities<IEntityApp>(entitiesAssembly);
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            modelBuilder.ApplyConfigurationsFromAssembly(entitiesAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();

            modelBuilder.Entity<ProductPriceHistory>().HasMany(x => x.ProductPriceOptionValues)
                .WithMany(x => x.ProductPriceHistories).UsingEntity(x => x.ToTable("ProductPriceHistoryToOptionValues"));
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Rollback();
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Commit();
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Update(entity);
        }
        public override void Dispose()
        {
            _transaction?.Dispose();
            base.Dispose();
        }
        public int SaveAllChanges()
        {
            return base.SaveChanges();
        }
    }

}
