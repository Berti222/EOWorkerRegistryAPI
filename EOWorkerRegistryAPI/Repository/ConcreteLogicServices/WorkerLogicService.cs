using EOWorkerRegistryAPI.Model;

namespace EOWorkerRegistryAPI.Repository.ConcreteLogicServices
{
    public class WorkerLogicService : LogicService<Worker>, IWorkerLogicService
    {
        public WorkerLogicService(WorkerRegisterContext context) : base(context)
        {
        }
    }
}
