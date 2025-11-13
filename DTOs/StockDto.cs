

public class StockDto : BaseDto
{
    public Guid ItemId { get; set; } = default!; // FK
    public Guid WarehouseId { get; set; } = default!; // FK
    public Guid StorageLocationId { get; set; } = default!; // FK
    public int QuantityOnHand { get; set; } = 0;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}



public class StockCreateDto
{
    
    public Guid ItemId { get; set; } = default!; // FK
    public Guid WarehouseId { get; set; } = default!; // FK
    public Guid StorageLocationId { get; set; } = default!; // FK
    public int QuantityOnHand { get; set; } = 0;
}
