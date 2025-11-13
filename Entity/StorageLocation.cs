public class StorageLocation : Base
{
    public Guid WarehouseId { get; set; } = default!; // FK
    public string Code { get; set; } = default!;
    public string Zone { get; set; } = default!;
    public string Rack { get; set; } = default!;
    public string Bin { get; set; } = default!;
    public int Capacity { get; set; } = 0;

    // Navigation
    public Warehouse? Warehouse { get; set; }
    public List<Stock> Stocks { get; set; } = new List<Stock>();
}
