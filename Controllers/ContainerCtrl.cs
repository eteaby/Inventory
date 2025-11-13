using AutoMapper;
using Inventory.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContainerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Container
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var containers = await _unitOfWork.Containers.GetAllAsync();
            var containerDtos = _mapper.Map<IEnumerable<ContainerDto>>(containers);
            return Ok(containerDtos);
        }
        // GET: api/Container/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var container = await _unitOfWork.Containers.GetByIdAsync(id);
            if (container == null) return NotFound();

            var dto = _mapper.Map<ContainerDto>(container);
            return Ok(dto);
        }

        // POST: api/Container
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContainerCreateDto dto)
        {
            var container = _mapper.Map<Container>(dto);

            await _unitOfWork.Containers.AddAsync(container);
            await _unitOfWork.CommitAsync();

            var resultDto = _mapper.Map<ContainerDto>(container);
            return CreatedAtAction(nameof(GetById), new { id = container.Id }, resultDto);
        }

        // PUT: api/Container/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ContainerDto dto)
        {
            var existing = await _unitOfWork.Containers.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            _unitOfWork.Containers.Update(existing);
            await _unitOfWork.CommitAsync();

            return Ok(_mapper.Map<ContainerDto>(existing));
        }

        // DELETE: api/Container/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _unitOfWork.Containers.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Containers.Delete(existing);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        // Optional: GET containers by ItemId
        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetByItem(string itemId)
        {
            var containers = await _unitOfWork.Containers.FindAsync(c => c.ItemId == itemId);
            var dtos = _mapper.Map<IEnumerable<ContainerDto>>(containers);
            return Ok(dtos);
        }
    }
}
