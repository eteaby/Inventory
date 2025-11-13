
public interface IContainerService
{
    Task<IEnumerable<ContainerDto>> GetAllAsync();
    Task<ContainerDto?> GetByIdAsync(Guid id);
    Task<ContainerDto> CreateAsync(ContainerCreateDto dto);
    Task<ContainerDto?> UpdateAsync(Guid id, ContainerDto dto);
    Task<bool> DeleteAsync(Guid id);

    // Example of additional logic: find containers by item
    Task<IEnumerable<ContainerDto>> GetByItemIdAsync(string itemId);
}
