// 3. Warehouse DTO
public class WarehouseDto : BaseDto
{
    public string WarehouseName { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Manager { get; set; } = default!;
}

public class WarehouseCreateDto 
{
    public string WarehouseName { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Manager { get; set; } = default!;
}
