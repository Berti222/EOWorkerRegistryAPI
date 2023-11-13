using System.ComponentModel.DataAnnotations;

namespace EOWorkerRegistryAPI.Model
{
    public class OrganizationalUnit : Entity
    {
        [MaxLength(255)]
        public string Abbreviation { get; set; }
        public virtual List<Worker> Workers { get; set; }
    }
}
