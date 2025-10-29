public class Supplier
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Navigation
    public ICollection<Inbound>? Inbounds { get; set; }
    public ICollection<PurchaseOrder>? PurchaseOrders { get; set; } // Add this
}