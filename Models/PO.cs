public class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int SupplierId { get; set; }
    public int WarehouseId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";

    // Navigation
    public Supplier? Supplier { get; set; }
    public Warehouse? Warehouse { get; set; }
    public ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
}
