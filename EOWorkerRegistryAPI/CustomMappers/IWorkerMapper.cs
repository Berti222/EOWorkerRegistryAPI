using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.DTOs.GetDTOs;
using EOWorkerRegistryAPI.Model;

namespace EOWorkerRegistryAPI.CustomMappers
{
    public interface IWorkerMapper
    {
        IEnumerable<WorkerGetDTO> MapCollectionToGetDTO(IEnumerable<Worker> collection);
        Task<Worker> MapFromCreateUpdateDTOAsync(WorkerCUDTO source, Worker entityInDb = null);
        WorkerGetDTO MapToGetDTO(Worker source, bool isSuperior = false);
    }
}