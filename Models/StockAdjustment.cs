public class StockAdjustment
{
    public int AdjustmentId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public string AdjustmentType { get; set; } = string.Empty; // Loss, Damage, Correction
    public int QuantityAdjusted { get; set; }
    public string Reason { get; set; } = string.Empty;
    public int AdjustedBy { get; set; }
    public DateTime AdjustmentDate { get; set; } = DateTime.UtcNow;

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
    public User? Adjuster { get; set; }
}
