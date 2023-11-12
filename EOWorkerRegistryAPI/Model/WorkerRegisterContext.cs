using Microsoft.EntityFrameworkCore;

namespace EOWorkerRegistryAPI.Model
{
    public class WorkerRegisterContext : DbContext
    {
        public WorkerRegisterContext(DbContextOptions<WorkerRegisterContext> options)
            : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
    }
}
