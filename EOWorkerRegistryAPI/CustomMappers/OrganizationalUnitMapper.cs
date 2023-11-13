using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.DTOs.GetDTOs;
using EOWorkerRegistryAPI.Model;
using EOWorkerRegistryAPI.Repository;

namespace EOWorkerRegistryAPI.CustomMappers
{
    public class OrganizationalUnitMapper : IOrganizationalUnitMapper
    {
        public IEnumerable<OrganizationalUnitGetDTO> MapCollectionToGetDTO(IEnumerable<OrganizationalUnit> collection)
        {
            foreach (var item in collection)
            {
                yield return MapToGetDTO(item);
            }
        }

        public OrganizationalUnitGetDTO MapToGetDTO(OrganizationalUnit source)
        {
            return new OrganizationalUnitGetDTO
            {
                Id = source.Id,
                Name = source.Name,
                Abbreviation = source.Abbreviation
            };
        }

        public OrganizationalUnit MapFromCreateUpdateDTO(OrganizationalUnitCUDTO source, OrganizationalUnit entityInDb = null)
        {
            if (entityInDb == null)
            {
                return new OrganizationalUnit
                {
                    Name = source.Name,
                    Abbreviation = source.Abbreviation
                };
            }
            else
            {
                entityInDb.Name = source.Name;
                entityInDb.Abbreviation = source.Abbreviation;
                return entityInDb;
            }
        }
    }
}
