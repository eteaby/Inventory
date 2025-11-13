using Microsoft.AspNetCore.Mvc;


namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageLocationController : ControllerBase
    {
        private readonly IStorageLocationService _service;

        public StorageLocationController(IStorageLocationService service)
        {
            _service = service;
        }

        // --- CRUD ---

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _service.GetAllAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var location = await _service.GetByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StorageLocationCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StorageLocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        // --- Extended Logic ---

        [HttpGet("{id}/capacity")]
        public async Task<IActionResult> GetAvailableCapacity(Guid id)
        {
            try
            {
                var capacity = await _service.GetAvailableCapacityAsync(id);
                return Ok(new { LocationId = id, AvailableCapacity = capacity });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}/can-store")]
        public async Task<IActionResult> CanStoreItem(Guid id, [FromQuery] Guid itemId, [FromQuery] int quantity)
        {
            var canStore = await _service.CanStoreItemAsync(id, itemId, quantity);
            return Ok(new { LocationId = id, ItemId = itemId, Quantity = quantity, CanStore = canStore });
        }

        [HttpGet("empty")]
        public async Task<IActionResult> GetEmptyLocations()
        {
            var result = await _service.GetEmptyLocationsAsync();
            return Ok(result);
        }

        [HttpGet("occupied")]
        public async Task<IActionResult> GetOccupiedLocations()
        {
            var result = await _service.GetOccupiedLocationsAsync();
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? zone, [FromQuery] string? rack)
        {
            var result = await _service.SearchAsync(zone, rack);
            return Ok(result);
        }
    }
}
