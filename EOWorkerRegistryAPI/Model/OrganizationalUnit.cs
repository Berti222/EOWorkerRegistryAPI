namespace EOWorkerRegistryAPI.Model
{
    public class OrganizationalUnit : Entity
    {
        public string Abbreviation { get; set; }
        public virtual List<Worker> Workers { get; set; }
    }
}
