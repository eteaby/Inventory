// 14. CycleCount DTO
public class CycleCountDto : BaseDto
{
    public Guid WarehouseId { get; set; } = default!;
    public Guid ItemId { get; set; } = default!;
    public int CountedQty { get; set; } = 0;
    public int SystemQty { get; set; } = 0;
    public int Variance { get; set; } = 0;
    public string CountedBy { get; set; } = default!;
    public DateTime Date { get; set; }
}
