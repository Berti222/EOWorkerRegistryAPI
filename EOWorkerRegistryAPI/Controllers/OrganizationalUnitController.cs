using EOWorkerRegistryAPI.CustomMappers;
using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.Repository.ConcreteLogicServices;
using Microsoft.AspNetCore.Mvc;

namespace EOWorkerRegistryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationalUnitController : ControllerBase
    {
        private readonly IOrganizationalUnitLogicService organizationalUnitLogicService;
        private readonly IOrganizationalUnitMapper organizationalUnitMapper;

        public OrganizationalUnitController(IOrganizationalUnitLogicService organizationalUnitLogicService,
                                            IOrganizationalUnitMapper organizationalUnitMapper)
        {
            this.organizationalUnitLogicService = organizationalUnitLogicService;
            this.organizationalUnitMapper = organizationalUnitMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetByProperties([FromQuery] string name = "", string abbrevation = "")
        {
            var query = await organizationalUnitLogicService.Query(null);
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(ou => ou.Name == name);
            if (!string.IsNullOrWhiteSpace(abbrevation))
                query = query.Where(ou => ou.Abbreviation == abbrevation);

            var resultListRaw = query.ToList();
            if (resultListRaw.Count == 0)
                return NotFound();

            var resulList = organizationalUnitMapper.MapCollectionToGetDTO(resultListRaw);
            return Ok(resulList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var result = await organizationalUnitLogicService.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            var mappedResult = organizationalUnitMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrganizationalUnitCUDTO dto)
        {
            if (dto == null)
                return BadRequest();

            var entityForCreate = organizationalUnitMapper.MapFromCreateUpdateDTO(dto);
            var result = await organizationalUnitLogicService.AddAsync(entityForCreate);

            var mappedResult = organizationalUnitMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] OrganizationalUnitCUDTO dto)
        {
            var entityInDb = await organizationalUnitLogicService.GetByIdAsync(id);
            if (entityInDb == null)
                return BadRequest("The entity is not exists yet!");

            var entityForCreate = organizationalUnitMapper.MapFromCreateUpdateDTO(dto, entityInDb);
            var result = await organizationalUnitLogicService.UpdateAsync(entityForCreate);

            var mappedResult = organizationalUnitMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await organizationalUnitLogicService.GetByIdAsync(id);
            if (result == null)
                BadRequest("Entiy is not exist.");

            await organizationalUnitLogicService.DeleteAsync(result);
            return NoContent();
        }
    }
}