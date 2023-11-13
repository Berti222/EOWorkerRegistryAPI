using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EOWorkerRegistryAPI.Model
{
    public class Worker : Entity
    {
        [MaxLength(255)]
        public string Rank { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }

        public long? SuperiorId { get; set; }
        public virtual Worker Superior { get; set; }
        public virtual List<Worker> Emploies { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }
    }
}
