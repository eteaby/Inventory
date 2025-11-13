
namespace Inventory.Repositories.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto?> GetByIdAsync(Guid id);
        Task<WarehouseDto> CreateWarehouseAsync(WarehouseCreateDto dto);
        Task<WarehouseDto?> UpdateAsync(Guid id, WarehouseDto dto);
        Task<bool> DeleteAsync(Guid id);

        // Add custom methods if needed, e.g., search by location
        Task<IEnumerable<WarehouseDto>> SearchByLocationAsync(string location);
    }
}
