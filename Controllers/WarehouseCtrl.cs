using Microsoft.AspNetCore.Mvc;
using Inventory.Repositories.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _warehouseService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var warehouse = await _warehouseService.GetByIdAsync(id);
        if (warehouse == null) return NotFound();
        return Ok(warehouse);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WarehouseCreateDto dto)
    {
        var created = await _warehouseService.CreateWarehouseAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WarehouseDto dto)
    {
        var updated = await _warehouseService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _warehouseService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string location)
    {
        var results = await _warehouseService.SearchByLocationAsync(location);
        return Ok(results);
    }
}
