// 6. StockTransaction DTO
public class StockTransactionDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public Guid WarehouseId { get; set; } = default!;
    public string TransactionType { get; set; } = default!;
    public int Quantity { get; set; } = 0;
    public DateTime Date { get; set; }
    public string ReferenceNo { get; set; } = default!;
    public string PerformedBy { get; set; } = default!;
    public Guid VendorId { get; set; } = default!;
    public Guid CustomerId { get; set; } = default!;
    public string Remarks { get; set; } = default!;
}
