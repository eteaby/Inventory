
public class PurchaseOrderItemTax
{
    public int PurchaseOrderItemTaxId { get; set; }
    public int PurchaseOrderItemId { get; set; }
    public int TaxId { get; set; }
    public decimal TaxAmount { get; set; }

    // Navigation
    public PurchaseOrderItem? PurchaseOrderItem { get; set; }
    public Tax? Tax { get; set; }
}
