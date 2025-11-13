
    // Interface
    public interface IStorageLocationService
    {
        Task<IEnumerable<StorageLocationDto>> GetAllAsync();
        Task<StorageLocationDto?> GetByIdAsync(Guid id);
        Task<StorageLocationDto> CreateAsync(StorageLocationCreateDto dto);
        Task<StorageLocationDto?> UpdateAsync(Guid id, StorageLocationDto dto);
        Task<bool> DeleteAsync(Guid id);

        Task<int> GetAvailableCapacityAsync(Guid storageLocationId);
        Task<bool> CanStoreItemAsync(Guid storageLocationId, Guid itemId, int quantity);
        Task<IEnumerable<StorageLocationDto>> GetEmptyLocationsAsync();
        Task<IEnumerable<StorageLocationDto>> GetOccupiedLocationsAsync();
        Task<IEnumerable<StorageLocationDto>> SearchAsync(string? zone, string? rack);
    }

