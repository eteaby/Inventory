public class ReorderAlert
{
    public int ReorderId { get; set; }
    public int ItemId { get; set; }
    public int WarehouseId { get; set; }
    public int CurrentStock { get; set; }
    public int ReorderLevel { get; set; }
    public int SuggestedQuantity { get; set; }
    public DateTime AlertDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending"; // Pending / Ordered / Received

    // Navigation
    public Item? Item { get; set; }
    public Warehouse? Warehouse { get; set; }
}
