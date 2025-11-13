// 4. StorageLocation DTO
public class StorageLocationDto : BaseDto
{
    public Guid WarehouseId { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Zone { get; set; } = default!;
    public string Rack { get; set; } = default!;
    public string Bin { get; set; } = default!;
    public int Capacity { get; set; } = 0;
}

public class StorageLocationCreateDto 
{
    public Guid WarehouseId { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Zone { get; set; } = default!;
    public string Rack { get; set; } = default!;
    public string Bin { get; set; } = default!;
    public int Capacity { get; set; } = 0;
}
