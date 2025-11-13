
namespace Inventory.Repositories.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto?> GetByIdAsync(Guid id);
        Task<ItemDto> CreateAsync(ItemCreateDto dto);
        Task<ItemDto?> UpdateAsync(Guid id, ItemDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
