
public interface IStockAdjustmentService
{
    Task<IEnumerable<StockAdjustmentDto>> GetAllAsync();
    Task<StockAdjustmentDto?> GetByIdAsync(Guid id);
    Task<StockAdjustmentDto> CreateAsync(StockAdjustmentCreateDto dto);
    Task<StockAdjustmentDto?> UpdateAsync(Guid id, StockAdjustmentDto dto);
    Task<bool> DeleteAsync(Guid id);
}
