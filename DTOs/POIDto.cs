public class PurchaseOrderItemDto
{
    public int PurchaseOrderItemId { get; set; }
    public int PurchaseOrderId { get; set; }
    public int ItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
