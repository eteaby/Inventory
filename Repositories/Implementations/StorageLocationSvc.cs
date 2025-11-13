using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StorageLocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // --- CRUD ---

        public async Task<IEnumerable<StorageLocationDto>> GetAllAsync()
        {
            var locations = await _unitOfWork.StorageLocations.GetAllAsync();
            return _mapper.Map<IEnumerable<StorageLocationDto>>(locations);
        }

        public async Task<StorageLocationDto?> GetByIdAsync(Guid id)
        {
            var location = await _unitOfWork.StorageLocations.GetByIdAsync(id);
            return location == null ? null : _mapper.Map<StorageLocationDto>(location);
        }

        public async Task<StorageLocationDto> CreateAsync(StorageLocationCreateDto dto)
        {
            var entity = _mapper.Map<StorageLocation>(dto);
            await _unitOfWork.StorageLocations.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StorageLocationDto>(entity);
        }

        public async Task<StorageLocationDto?> UpdateAsync(Guid id, StorageLocationDto dto)
        {
            var existing = await _unitOfWork.StorageLocations.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.StorageLocations.Update(existing);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StorageLocationDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.StorageLocations.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.StorageLocations.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }

        // --- Extended Logic ---

        // 1. Get available capacity
        public async Task<int> GetAvailableCapacityAsync(Guid storageLocationId)
        {
            var location = await _unitOfWork.StorageLocations.GetByIdAsync(storageLocationId);
            if (location == null)
                throw new KeyNotFoundException("Storage location not found.");

            var stocks = await _unitOfWork.Stocks.FindAsync(s => s.StorageLocationId == storageLocationId);
            var used = stocks.Sum(s => s.QuantityOnHand);

            return Math.Max(location.Capacity - used, 0);
        }

        // 2. Check if item can fit
        public async Task<bool> CanStoreItemAsync(Guid storageLocationId, Guid itemId, int quantity)
        {
            var available = await GetAvailableCapacityAsync(storageLocationId);
            return quantity <= available;
        }

        // 3. List empty locations
        public async Task<IEnumerable<StorageLocationDto>> GetEmptyLocationsAsync()
        {
            var all = await _unitOfWork.StorageLocations.GetAllAsync();
            var empty = new List<StorageLocation>();

            foreach (var loc in all)
            {
                var stocks = await _unitOfWork.Stocks.FindAsync(s => s.StorageLocationId == loc.Id);
                if (!stocks.Any())
                    empty.Add(loc);
            }

            return _mapper.Map<IEnumerable<StorageLocationDto>>(empty);
        }

        // 4. List occupied locations
        public async Task<IEnumerable<StorageLocationDto>> GetOccupiedLocationsAsync()
        {
            var all = await _unitOfWork.StorageLocations.GetAllAsync();
            var occupied = new List<StorageLocation>();

            foreach (var loc in all)
            {
                var stocks = await _unitOfWork.Stocks.FindAsync(s => s.StorageLocationId == loc.Id);
                if (stocks.Any())
                    occupied.Add(loc);
            }

            return _mapper.Map<IEnumerable<StorageLocationDto>>(occupied);
        }

        // 5. Search by zone or rack
        public async Task<IEnumerable<StorageLocationDto>> SearchAsync(string? zone, string? rack)
        {
            var query = await _unitOfWork.StorageLocations.FindAsync(loc =>
                (string.IsNullOrEmpty(zone) || loc.Zone == zone) &&
                (string.IsNullOrEmpty(rack) || loc.Rack == rack)
            );

            return _mapper.Map<IEnumerable<StorageLocationDto>>(query);
        }
    }
}

