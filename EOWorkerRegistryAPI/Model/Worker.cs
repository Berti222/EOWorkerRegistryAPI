using System.ComponentModel.DataAnnotations.Schema;

namespace EOWorkerRegistryAPI.Model
{
    public class Worker : Entity
    {
        public string Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public long SuperiorId { get; set; }
        [ForeignKey(nameof(SuperiorId))]
        public virtual Worker Superior { get; set; }

        public long OrganizationalUnitId { get; set; }
        [ForeignKey(nameof(OrganizationalUnitId))]
        public OrganizationalUnit OrganizationalUnit { get; set; }
    }
}
