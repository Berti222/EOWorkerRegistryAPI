using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
                       .HasOne(e => e.Superior)
                       .WithMany(u => u.Emploies)
                       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Worker>()
                       .HasOne(e => e.OrganizationalUnit)
                       .WithMany(u => u.Workers)
                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
