public class CycleCount : Base
{
    public Guid WarehouseId { get; set; } = default!; // FK
    public Guid ItemId { get; set; } = default!; // FK
    public int CountedQty { get; set; } = 0;
    public int SystemQty { get; set; } = 0;
    public int Variance { get; set; } = 0;
    public string CountedBy { get; set; } = default!;
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Navigation
    public Warehouse? Warehouse { get; set; }
    public Item? Item { get; set; }
}
