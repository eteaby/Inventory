// 7. Batch DTO
public class BatchDto : BaseDto
{
    public Guid ItemId { get; set; } = default!;
    public string BatchNumber { get; set; } = default!;
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; } = 0;
}
