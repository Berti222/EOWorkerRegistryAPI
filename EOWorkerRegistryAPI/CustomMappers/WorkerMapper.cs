using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.DTOs.GetDTOs;
using EOWorkerRegistryAPI.Model;
using EOWorkerRegistryAPI.Repository.ConcreteLogicServices;

namespace EOWorkerRegistryAPI.CustomMappers
{
    public class WorkerMapper : IWorkerMapper
    {
        private readonly IOrganizationalUnitMapper organizationalUnitMapper;
        private readonly IOrganizationalUnitLogicService organizationalUnitLogicService;

        public WorkerMapper(IOrganizationalUnitMapper organizationalUnitMapper, IOrganizationalUnitLogicService organizationalUnitLogicService)
        {
            this.organizationalUnitMapper = organizationalUnitMapper;
            this.organizationalUnitLogicService = organizationalUnitLogicService;
        }
        public IEnumerable<WorkerGetDTO> MapCollectionToGetDTO(IEnumerable<Worker> collection)
        {
            foreach (var item in collection)
            {
                yield return MapToGetDTO(item);
            }
        }

        public WorkerGetDTO MapToGetDTO(Worker source, bool isSuperior = false)
        {
            OrganizationalUnitGetDTO organizationalUnitDTO = null;
            if (source.OrganizationalUnit != null)
                organizationalUnitDTO = organizationalUnitMapper.MapToGetDTO(source.OrganizationalUnit);
            var result = new WorkerGetDTO
            {
                Id = source.Id,
                Name = source.Name,
                Rank = source.Rank,
                PhoneNumber = source.PhoneNumber,
                OrganizationalUnit = organizationalUnitDTO

            };
            if (!isSuperior && source.Superior != null)
            {
                var superiorDTO = MapToGetDTO(source.Superior, true);
                result.Superior = superiorDTO;
            }
            return result;
        }

        public async Task<Worker> MapFromCreateUpdateDTOAsync(WorkerCUDTO source, Worker entityInDb = null)
        {
            Worker superior = null;
            OrganizationalUnit organizationalUnit = null;
            if (source.OrganizationalUnitId.HasValue)
                organizationalUnit = await organizationalUnitLogicService.GetByIdAsync(source.OrganizationalUnitId.Value);

            Worker worker = entityInDb;
            if (entityInDb == null)
                worker = new Worker();

            worker.Name = source.Name;
            worker.Rank = source.Rank;
            worker.PhoneNumber = source.PhoneNumber;
            worker.UserName = source.UserName;
            worker.Password = source.Password;
            if (source.SuperiorId.HasValue)
                worker.SuperiorId = source.SuperiorId.Value;
            if (organizationalUnit != null)
                worker.OrganizationalUnit = organizationalUnit;

            return worker;
        }
    }
}
