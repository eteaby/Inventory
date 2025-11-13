// 16. InventoryValuation DTO
public class InventoryValuationDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public string Method { get; set; } = default!;
    public double UnitCost { get; set; } = 0;
    public double TotalValue { get; set; } = 0;
    public DateTime LastUpdated { get; set; }
}
