public class StockTransfer : Base
{
    public Guid FromWarehouseId { get; set; } = default!; // FK
    public Guid ToWarehouseId { get; set; } = default!; // FK
    public Guid ItemId { get; set; } = default!; // FK
    public int Quantity { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = default!;

    // Navigation
    public Warehouse? FromWarehouse { get; set; }
    public Warehouse? ToWarehouse { get; set; }
    public Item? Item { get; set; }
}
