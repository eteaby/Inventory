// StockAdjustment DTO
public class StockAdjustmentDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public Guid WarehouseId { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public int QuantityChange { get; set; }
    public string AdjustedBy { get; set; } = default!;
    public DateTime Date { get; set; }
}

// DTO for creating StockAdjustment
public class StockAdjustmentCreateDto
{
    public Guid ItemId { get; set; } = default!;
    public Guid WarehouseId { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public int QuantityChange { get; set; }
    public string AdjustedBy { get; set; } = default!;
}
