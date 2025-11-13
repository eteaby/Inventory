
namespace Inventory.Repositories.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockDto>> GetAllAsync();
        Task<StockDto?> GetByIdAsync(Guid id);
        Task<StockDto> CreateStockAsync(StockCreateDto dto);
        Task<StockDto?> UpdateAsync(Guid id, StockDto dto);
        Task<bool> DeleteAsync(Guid id);

        // Example of custom logic
        Task<IEnumerable<StockDto>> GetStockByItemAsync(string itemId);
    }
}
