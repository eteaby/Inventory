using Microsoft.AspNetCore.Mvc;
using Inventory.Repositories.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _stockService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var stock = await _stockService.GetByIdAsync(id);
        if (stock == null) return NotFound();
        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StockCreateDto dto)
    {
        var created = await _stockService.CreateStockAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] StockDto dto)
    {
        var updated = await _stockService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _stockService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("by-item/{itemId}")]
    public async Task<IActionResult> GetByItem(string itemId)
    {
        var stocks = await _stockService.GetStockByItemAsync(itemId);
        return Ok(stocks);
    }
}
