public class StockAdjustmentDto
{
    public int AdjustmentId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int QuantityAdjusted { get; set; }
    public string AdjustmentType { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public int AdjustedBy { get; set; }
    public int? AdjusterUserId { get; set; }
    public DateTime AdjustmentDate { get; set; }
}
