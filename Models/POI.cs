public class PurchaseOrderItem
{
    public int PurchaseOrderItemId { get; set; }
    public int PurchaseOrderId { get; set; }
    public int ItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;

    // Navigation
    public PurchaseOrder? PurchaseOrder { get; set; }
    public Item? Item { get; set; }
    public ICollection<PurchaseOrderItemTax>? PurchaseOrderItemTaxes { get; set; }
}
