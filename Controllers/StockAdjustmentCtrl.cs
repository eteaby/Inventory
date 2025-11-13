using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StockAdjustmentController : ControllerBase
{
    private readonly IStockAdjustmentService _service;

    public StockAdjustmentController(IStockAdjustmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var adjustments = await _service.GetAllAsync();
        return Ok(adjustments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var adjustment = await _service.GetByIdAsync(id);
        if (adjustment == null) return NotFound();
        return Ok(adjustment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StockAdjustmentCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] StockAdjustmentDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
