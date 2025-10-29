public class WarehouseDto
{
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int? ManagerId { get; set; }
}
