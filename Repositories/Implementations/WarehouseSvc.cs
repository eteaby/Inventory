using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WarehouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _unitOfWork.Warehouses.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
        }

        public async Task<WarehouseDto?> GetByIdAsync(Guid id)
        {
            var warehouse = await _unitOfWork.Warehouses.GetByIdAsync(id);
            return warehouse == null ? null : _mapper.Map<WarehouseDto>(warehouse);
        }

        public async Task<WarehouseDto> CreateWarehouseAsync(WarehouseCreateDto dto)
        {
            var warehouse = _mapper.Map<Warehouse>(dto);
            await _unitOfWork.Warehouses.AddAsync(warehouse);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<WarehouseDto>(warehouse);
        }

        public async Task<WarehouseDto?> UpdateAsync(Guid id, WarehouseDto dto)
        {
            var existing = await _unitOfWork.Warehouses.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.Warehouses.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<WarehouseDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Warehouses.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Warehouses.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }

        // Example of custom logic
        public async Task<IEnumerable<WarehouseDto>> SearchByLocationAsync(string location)
        {
            var warehouses = await _unitOfWork.Warehouses.FindAsync(w => w.Location.Contains(location));
            return _mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
        }
    }
}
