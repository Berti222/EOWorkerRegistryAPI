using EOWorkerRegistryAPI.CustomMappers;
using EOWorkerRegistryAPI.DTOs.CreateDTOs;
using EOWorkerRegistryAPI.Repository.ConcreteLogicServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EOWorkerRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerLogicService workerLogicService;
        private readonly IWorkerMapper workerMapper;

        public WorkerController(IWorkerLogicService workerLogicService, IWorkerMapper workerMapper)
        {
            this.workerLogicService = workerLogicService;
            this.workerMapper = workerMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetByProperties([FromQuery] string name = "", string rank = "", string phoneNumber = "")
        {
            var query = await workerLogicService.Query(ou => ou.Active);
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(ou => ou.Name == name);
            if (!string.IsNullOrWhiteSpace(rank))
                query = query.Where(ou => ou.Rank == rank);
            if (!string.IsNullOrWhiteSpace(phoneNumber))
                query = query.Where(ou => ou.Rank == phoneNumber);

            query = query.Include(x => x.OrganizationalUnit).Include(x => x.Superior);

            var resultListRaw = query.ToList();
            if (resultListRaw.Count == 0)
                return NotFound();

            var resulList = workerMapper.MapCollectionToGetDTO(resultListRaw);
            return Ok(resulList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var query = await workerLogicService.Query(w => w.Id == id);
            query = query.Include(x => x.OrganizationalUnit).Include(x => x.Superior);

            var result = query.FirstOrDefault();
            if (result == null)
                return NotFound();

            var mappedResult = workerMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] WorkerCUDTO dto)
        {
            if (dto == null)
                return BadRequest();

            var entityForCreate = await workerMapper.MapFromCreateUpdateDTOAsync(dto);
            var result = await workerLogicService.AddAsync(entityForCreate);

            var mappedResult = workerMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] WorkerCUDTO dto)
        {
            var entityInDb = await workerLogicService.GetByIdAsync(id);
            if (entityInDb == null)
                return BadRequest("The entity is not exists yet!");

            var entityForCreate = await workerMapper.MapFromCreateUpdateDTOAsync(dto, entityInDb);
            var result = await workerLogicService.UpdateAsync(entityForCreate);

            var mappedResult = workerMapper.MapToGetDTO(result);
            return Ok(mappedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await workerLogicService.GetByIdAsync(id);
            if (result == null)
                BadRequest("Entiy is not exist.");

            await workerLogicService.DeleteAsync(result);
            return NoContent();
        }
    }
}
