using EOWorkerRegistryAPI.Model;

namespace EOWorkerRegistryAPI.Repository.ConcreteLogicServices
{
    public class OrganizationalUnitLogicService : LogicService<OrganizationalUnit>, IOrganizationalUnitLogicService
    {
        public OrganizationalUnitLogicService(WorkerRegisterContext context) : base(context)
        {
        }
    }
}
