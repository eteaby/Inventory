public class ItemDto
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public int ReorderLevel { get; set; }
    public int SafetyStock { get; set; }
    public string? Description { get; set; }
    public string? Barcode { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
