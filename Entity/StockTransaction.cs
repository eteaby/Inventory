public class StockTransaction : Base
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid WarehouseId { get; set; } = default!; // FK
    public string TransactionType { get; set; } = default!; // IN/OUT/ADJUST/TRANSFER
    public int Quantity { get; set; } = 0;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string ReferenceNo { get; set; } = default!;
    public string PerformedBy { get; set; } = default!; // FK User
    public Guid? VendorId { get; set; } // FK Vendor (for IN)
    public Guid? CustomerId { get; set; } // FK Customer/Department (for OUT)
    public string? Remarks { get; set; }

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
}
