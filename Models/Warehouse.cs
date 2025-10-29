public class Warehouse
{
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int? ManagerId { get; set; }

    // Navigation
    public User? Manager { get; set; }
    public ICollection<Stock>? Stocks { get; set; }
    public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
}