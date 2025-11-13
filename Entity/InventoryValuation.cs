public class InventoryValuation : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid? StockId { get; set; } // optional FK
    public Guid? BatchId { get; set; } // optional FK
    public string Method { get; set; } = default!; // FIFO/LIFO/AVG
    public decimal UnitCost { get; set; } = 0;
    public decimal TotalValue { get; set; } = 0;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    // Navigation
    public Item? Item { get; set; }
    public Stock? Stock { get; set; }
    public Batch? Batch { get; set; }
}
