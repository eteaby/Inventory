// 1. Item DTO
public class ItemDto : BaseDto
{
    public string ItemName { get; set; } = default!;
    public string SKU { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public string UnitOfMeasure { get; set; } = default!;
    public int ReorderLevel { get; set; } = 0;
    public int SafetyStock { get; set; } = 0;
    public double CostPrice { get; set; } = 0;
    public double SellingPrice { get; set; } = 0;
    public DateTime? ExpiryDate { get; set; }
}

public class ItemCreateDto
{
    public string ItemName { get; set; } = default!;
    public string SKU { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public string UnitOfMeasure { get; set; } = default!;
    public int ReorderLevel { get; set; } = 0;
    public int SafetyStock { get; set; } = 0;
    public double CostPrice { get; set; } = 0;
    public double SellingPrice { get; set; } = 0;
    public DateTime? ExpiryDate { get; set; }
}
