public interface IReorderRuleService
{
    Task<IEnumerable<ReorderRuleDto>> GetAllAsync();
    Task<ReorderRuleDto?> GetByIdAsync(Guid id);
    Task<ReorderRuleDto> CreateAsync(ReorderRuleCreateDto dto);
    Task<ReorderRuleDto?> UpdateAsync(Guid id, ReorderRuleDto dto);
    Task<bool> DeleteAsync(Guid id);

    Task<IEnumerable<ReorderAlertDto>> GetLowStockAlertsAsync();
}
