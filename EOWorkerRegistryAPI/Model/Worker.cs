namespace EOWorkerRegistryAPI.Model
{
    public class Worker : Entity
    {
        public string Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public long? SuperiorId { get; set; }
        public virtual Worker Superior { get; set; }
        public virtual List<Worker> Emploies { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }
    }
}
