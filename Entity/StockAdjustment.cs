public class StockAdjustment : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid WarehouseId { get; set; } = default!; // FK
    public string Reason { get; set; } = default!;
    public int QuantityChange { get; set; } = 0;
    public string AdjustedBy { get; set; } = default!; // FK User
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
}
