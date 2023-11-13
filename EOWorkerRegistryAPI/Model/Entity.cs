using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EOWorkerRegistryAPI.Model
{
    public abstract class Entity : IEntity, ICreatedModifiedBy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public long? ModifiedBy { get; set; }
        public long? CreatedBy { get; set; }
    }
}
