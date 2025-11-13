public class Stock : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid WarehouseId { get; set; } = default!; // FK
    public Guid StorageLocationId { get; set; } = default!; // FK
    public int QuantityOnHand { get; set; } = 0;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
    public StorageLocation? StorageLocation { get; set; }
    public List<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    public List<InventoryValuation> InventoryValuations { get; set; } = new List<InventoryValuation>();
}
