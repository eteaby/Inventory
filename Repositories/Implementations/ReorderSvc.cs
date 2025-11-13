using AutoMapper;
using Inventory.Repositories.Interfaces;

namespace Inventory.Repositories.Implementations
{
    public class ReorderRuleService : IReorderRuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReorderRuleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // --- CRUD Operations ---

        public async Task<IEnumerable<ReorderRuleDto>> GetAllAsync()
        {
            var rules = await _unitOfWork.ReorderRules.GetAllAsync();
            return _mapper.Map<IEnumerable<ReorderRuleDto>>(rules);
        }

        public async Task<ReorderRuleDto?> GetByIdAsync(Guid id)
        {
            var rule = await _unitOfWork.ReorderRules.GetByIdAsync(id);
            return rule == null ? null : _mapper.Map<ReorderRuleDto>(rule);
        }

        public async Task<ReorderRuleDto> CreateAsync(ReorderRuleCreateDto dto)
        {
            var rule = _mapper.Map<ReorderRule>(dto);
            await _unitOfWork.ReorderRules.AddAsync(rule);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ReorderRuleDto>(rule);
        }

        public async Task<ReorderRuleDto?> UpdateAsync(Guid id, ReorderRuleDto dto)
        {
            var existing = await _unitOfWork.ReorderRules.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _unitOfWork.ReorderRules.Update(existing);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ReorderRuleDto>(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _unitOfWork.ReorderRules.GetByIdAsync(id);
            if (existing == null) return false;

            _unitOfWork.ReorderRules.Delete(existing);
            await _unitOfWork.CommitAsync();
            return true;
        }

        // --- Low-stock alert logic ---
        public async Task<IEnumerable<ReorderAlertDto>> GetLowStockAlertsAsync()
        {
            var alerts = new List<ReorderAlertDto>();
            var rules = await _unitOfWork.ReorderRules.GetAllAsync();

            foreach (var rule in rules)
            {
                // stockItems uses Guid comparison
                var stockItems = await _unitOfWork.Stocks.FindAsync(s => s.ItemId == rule.ItemId);
                var totalQuantity = stockItems.Sum(s => s.QuantityOnHand);

                if (totalQuantity <= rule.ReorderLevel)
                {
                    alerts.Add(new ReorderAlertDto
                    {
                        ItemId = rule.ItemId,
                        Message = $"Stock is low for Item {rule.ItemId}. Current: {totalQuantity}, Reorder Level: {rule.ReorderLevel}",
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            return alerts;
        }
    }
}
