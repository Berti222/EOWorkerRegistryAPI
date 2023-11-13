using Microsoft.EntityFrameworkCore;

namespace EOWorkerRegistryAPI.Model
{
    public class WorkerRegisterContext : DbContext
    {
        public WorkerRegisterContext()
        {
        }
        public WorkerRegisterContext(DbContextOptions<WorkerRegisterContext> options)
            : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                       .HasMany(u => u.Emploies)
                       .WithOne(u => u.Superior)
                       .HasForeignKey(u => u.SuperiorId)
                       .OnDelete(DeleteBehavior.NoAction)
                       .IsRequired(false);

            modelBuilder.Entity<Worker>()
                       .HasOne(e => e.OrganizationalUnit)
                       .WithMany(u => u.Workers)
                       .OnDelete(DeleteBehavior.NoAction);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as ICreatedModifiedBy;

                if (entry.State == EntityState.Added)
                    entity.CreatedBy = StaticValues.SavingUpdatingUserId;

                entity.ModifiedBy = StaticValues.SavingUpdatingUserId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
