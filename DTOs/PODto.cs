public class PurchaseOrderDto
{
    public int PurchaseOrderId { get; set; }
    public string PONumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public int SupplierId { get; set; }
    public int WarehouseId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
}
