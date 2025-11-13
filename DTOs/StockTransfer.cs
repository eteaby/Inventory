// 11. StockTransfer DTO
public class StockTransferDto : BaseDto
{
    public Guid FromWarehouseId { get; set; } = default!;
    public Guid ToWarehouseId { get; set; } = default!;
    public Guid ItemId { get; set; } = default!;
    public int Quantity { get; set; } = 0;
    public DateTime Date { get; set; }
    public string Status { get; set; } = default!;
}
