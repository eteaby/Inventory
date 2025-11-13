using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDto>> GetAllAsync()
        {
            var stocks = await _unitOfWork.Stocks.GetAllAsync();
            return _mapper.Map<IEnumerable<StockDto>>(stocks);
        }

        public async Task<StockDto?> GetByIdAsync(Guid id)
        {
            var stock = await _unitOfWork.Stocks.GetByIdAsync(id);
            return stock == null ? null : _mapper.Map<StockDto>(stock);
        }

        public async Task<StockDto> CreateStockAsync(StockCreateDto dto)
        {
            var stock = _mapper.Map<Stock>(dto);
            stock.LastUpdated = DateTime.UtcNow;

            await _unitOfWork.Stocks.AddAsync(stock);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<StockDto>(stock);
        }

        public async Task<StockDto?> UpdateAsync(Guid id, StockDto dto)
        {
            var existing = await _unitOfWork.Stocks.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            existing.LastUpdated = DateTime.UtcNow;
            _unitOfWork.Stocks.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<StockDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.Stocks.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.Stocks.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<StockDto>> GetStockByItemAsync(string itemId)
        {
            var stocks = await _unitOfWork.Stocks.FindAsync(s => s.ItemId == itemId);
            return _mapper.Map<IEnumerable<StockDto>>(stocks);
        }
    }
}
