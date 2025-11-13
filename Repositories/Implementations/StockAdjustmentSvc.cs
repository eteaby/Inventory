using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockAdjustmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockAdjustmentDto>> GetAllAsync()
        {
            var adjustments = await _unitOfWork.StockAdjustments.GetAllAsync();
            return _mapper.Map<IEnumerable<StockAdjustmentDto>>(adjustments);
        }

        public async Task<StockAdjustmentDto?> GetByIdAsync(Guid id)
        {
            var adjustment = await _unitOfWork.StockAdjustments.GetByIdAsync(id);
            return adjustment == null ? null : _mapper.Map<StockAdjustmentDto>(adjustment);
        }

        public async Task<StockAdjustmentDto> CreateAsync(StockAdjustmentCreateDto dto)
        {
            var adjustment = _mapper.Map<StockAdjustment>(dto);
            adjustment.Date = DateTime.UtcNow; // set current time
            await _unitOfWork.StockAdjustments.AddAsync(adjustment);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<StockAdjustmentDto>(adjustment);
        }

        public async Task<StockAdjustmentDto?> UpdateAsync(Guid id, StockAdjustmentDto dto)
        {
            var existing = await _unitOfWork.StockAdjustments.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.StockAdjustments.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<StockAdjustmentDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.StockAdjustments.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.StockAdjustments.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
