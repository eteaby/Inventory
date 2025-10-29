public class Item
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string? Barcode { get; set; }
    public int CategoryId { get; set; }
    public string UnitOfMeasure { get; set; } = "pcs";
    public int ReorderLevel { get; set; }
    public int SafetyStock { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public DateTime? ExpiryDate { get; set; }

    // Navigation
    public Category? Category { get; set; }
}
