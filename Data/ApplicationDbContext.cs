using Data.Contracts;
using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext: DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbContext DbContext { get { return this; } }
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

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
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
        }
    }

}
