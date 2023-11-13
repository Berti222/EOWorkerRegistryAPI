using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.DTOs.GetDTOs;
using EOWorkerRegistryAPI.Model;

namespace EOWorkerRegistryAPI.CustomMappers
{
    public interface IOrganizationalUnitMapper
    {
        IEnumerable<OrganizationalUnitGetDTO> MapCollectionToGetDTO(IEnumerable<OrganizationalUnit> collection);
        OrganizationalUnit MapFromCreateUpdateDTO(OrganizationalUnitCUDTO source, OrganizationalUnit entityInDb = null);
        OrganizationalUnitGetDTO MapToGetDTO(OrganizationalUnit source);
    }
}