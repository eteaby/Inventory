using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ReorderRuleController : ControllerBase
{
    private readonly IReorderRuleService _service;

    public ReorderRuleController(IReorderRuleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rule = await _service.GetByIdAsync(id);
        return rule == null ? NotFound() : Ok(rule);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReorderRuleCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ReorderRuleDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    // Endpoint to get low-stock alerts
    [HttpGet("alerts")]
    public async Task<IActionResult> GetLowStockAlerts() =>
        Ok(await _service.GetLowStockAlertsAsync());
}
 