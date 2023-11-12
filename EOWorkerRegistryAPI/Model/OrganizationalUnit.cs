namespace EOWorkerRegistryAPI.Model
{
    public class OrganizationalUnit : Entity
    {
        public string Abbreviation { get; set; }
        public virtual IQueryable<Worker> Workers { get; set; }
    }
}
